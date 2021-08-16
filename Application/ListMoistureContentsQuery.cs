using API.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.MoistureContents
{

    public class ListMoistureContentsQuery : IRequest<Result<List<MoistureContentDto>>>
    {
    }

    public class ListMoistureContentsHandler : IRequestHandler<ListMoistureContentsQuery, Result<List<MoistureContentDto>>>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ListMoistureContentsHandler(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<List<MoistureContentDto>>> Handle(ListMoistureContentsQuery request, CancellationToken cancellationToken)
        {
            var moistureContents = await _dataContext.MoistureContents
                                        .Include(m => m.Project)
                                        .Include(m => m.SourceMaterial)
                                        .Include(m => m.Specification)
                                        .Include(m => m.Sample)
                                        .Include(m => m.Preparation)
                                        .Include(m => m.Preparation.Balance)
                                        .Include(m => m.Preparation.Oven)
                                        .Include(m => m.StandardTestMethod)
                                        .ToListAsync();

            if (moistureContents is null) return Result<List<MoistureContentDto>>.Failure("Id Not Found");
            var moistureContentDtoList = new List<MoistureContentDto>();

            foreach (var moistureContent in moistureContents)
            {
                var moistureContentDto = new MoistureContentDto();
                _mapper.Map(moistureContent, moistureContentDto);
                moistureContentDtoList.Add(moistureContentDto);
            }

            return Result<List<MoistureContentDto>>.Success(moistureContentDtoList);
        }
    }

}
