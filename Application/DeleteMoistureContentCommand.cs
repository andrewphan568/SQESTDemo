using FluentValidation;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class DeleteMoistureContentCommand : IRequest<Result<Unit>>
    {
        public Guid Id { set; get; }
        public DeleteMoistureContentCommand(Guid id)
        {
            Id = id;
        }
    }
    public class DeleteMoistureContentCommandValidator : AbstractValidator<DeleteMoistureContentCommand>
    {
        public DeleteMoistureContentCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }

    public class DeleteMoistureContentCommandHandler : IRequestHandler<DeleteMoistureContentCommand, Result<Unit>>
    {
        private readonly DataContext _dataContext;
        public DeleteMoistureContentCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;        
        }
         

        public async Task<Result<Unit>> Handle(DeleteMoistureContentCommand request, CancellationToken cancellationToken)
        {
            var moistureContent = await _dataContext.MoistureContents.FindAsync(request.Id);
            if (moistureContent is null) return Result<Unit>.Failure("Id Not Found");

            _dataContext.Remove(moistureContent);

            var result = await _dataContext.SaveChangesAsync() > 0;

            if (!result) return Result<Unit>.Failure("Failed to delete moistureContent");

            return Result<Unit>.Success(Unit.Value);

        }
    }
}
