using API.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class GetMoistureContentQuery : IRequest<Result<MoistureContentDto>>
    {
        public Guid Id { set; get; }
        public GetMoistureContentQuery(Guid id)
        {
            Id = id;
        }
    }
    public class GetMoistureContentQueryValidator : AbstractValidator<GetMoistureContentQuery>
    {
        public GetMoistureContentQueryValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }

    public class GetMoistureContentHandler : IRequestHandler<GetMoistureContentQuery, Result<MoistureContentDto>>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public GetMoistureContentHandler(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }      

        public async Task<Result<MoistureContentDto>> Handle(GetMoistureContentQuery request, CancellationToken cancellationToken)
        {
             var moistureContent = await _dataContext.MoistureContents.FindAsync(request.Id);
            if (moistureContent is null)  return Result<MoistureContentDto>.Failure("Id Not Found");

            var moistureContentDto = new MoistureContentDto();
            _mapper.Map(moistureContent, moistureContentDto);

            return Result<MoistureContentDto>.Success(moistureContentDto);

        }
    }
}
