using API.DTOs;
using AutoMapper;
using Domain.Moisture;
using FluentValidation;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class UpdateMoistureContentCommand : IRequest<Result<Unit>>
    {
        public MoistureContent MoistureContent { set; get; }        
    }
    public class UpdateMoistureContentCommandValidator : AbstractValidator<UpdateMoistureContentCommand>
    {
        public UpdateMoistureContentCommandValidator()
        {
            RuleFor(c => c.MoistureContent).NotEmpty();
        }
    }

    public class UpdateMoistureContentCommandHandler : IRequestHandler<UpdateMoistureContentCommand, Result<Unit>>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public UpdateMoistureContentCommandHandler(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(UpdateMoistureContentCommand request, CancellationToken cancellationToken)
        {
            var moistureContent = await _dataContext.MoistureContents.FindAsync(request.MoistureContent.Id);

            if (moistureContent is null) return Result<Unit>.Failure("Not Found MoistureContent");

            _mapper.Map(request.MoistureContent, moistureContent);

            var result = await _dataContext.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to update Moisture Content");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
