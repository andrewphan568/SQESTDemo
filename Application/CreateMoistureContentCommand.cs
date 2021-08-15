using AutoMapper;
using Domain.Moisture;
using FluentValidation;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class CreateMoistureContentCommand : IRequest<Result<Unit>>
    {
        public MoistureContent MoistureContent { set; get; }
    }
    public class CreateMoistureContentCommandValidator : AbstractValidator<CreateMoistureContentCommand>
    {
        public CreateMoistureContentCommandValidator()
        {
            RuleFor(c => c.MoistureContent).NotEmpty();
            RuleFor(c => c.MoistureContent.Project).NotEmpty();
            RuleFor(c => c.MoistureContent.SourceMaterial).NotEmpty();
            RuleFor(c => c.MoistureContent.Specification).NotEmpty();
            RuleFor(c => c.MoistureContent.Sample).NotEmpty();
            RuleFor(c => c.MoistureContent.Preparation).NotEmpty();
            RuleFor(c => c.MoistureContent.StandardTestMethod).NotEmpty();
            RuleFor(c => c.MoistureContent.TareId).NotEmpty();
            RuleFor(c => c.MoistureContent.TareMass).NotEmpty();      
        }
    }

    public class CreateMoistureContentCommandHandler : IRequestHandler<CreateMoistureContentCommand, Result<Unit>>
    {
        private readonly DataContext _dataContext;    
        public CreateMoistureContentCommandHandler(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;       
        }

        public async Task<Result<Unit>> Handle(CreateMoistureContentCommand request, CancellationToken cancellationToken)
        {
            _dataContext.MoistureContents.Add(request.MoistureContent);

            var result = await _dataContext.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to create Moisture Content");

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
