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

        public IMapper Mapper { get; }

        public async Task<Result<List<MoistureContentDto>>> Handle(ListMoistureContentsQuery request, CancellationToken cancellationToken)
        {
           var moistureContents = await _dataContext.MoistureContents.ToListAsync();

            if (moistureContents is null) return Result<List<MoistureContentDto>>.Failure("Id Not Found");
            var moistureContentDtoList = new List<MoistureContentDto>();

            foreach (var moistureContent in moistureContents) {
                var moistureContentDto = new MoistureContentDto();
                _mapper.Map(moistureContent, moistureContentDto);

                // temporarily use this way to get child objects in moistureContent
                // will refactor after sovling the "seed owned types" issue when migrating database

                if (moistureContent.ProjectId is not null)
                {
                    var project = await _dataContext.Projects.FindAsync(moistureContent.ProjectId);
                    if (project is not null) moistureContentDto.Project = project;
                }

                if (moistureContent.SourceMaterialId is not null)
                {
                    var sourceMaterial = await _dataContext.SourceMaterials.FindAsync(moistureContent.SourceMaterialId);
                    if (sourceMaterial is not null) moistureContentDto.SourceMaterial = sourceMaterial;
                }

                if (moistureContent.SpecificationId is not null)
                {
                    var specification = await _dataContext.Specifications.FindAsync(moistureContent.SpecificationId);
                    if (specification is not null) moistureContentDto.Specification = specification;
                }

                if (moistureContent.SampleId is not null)
                {
                    var sample = await _dataContext.Samples.FindAsync(moistureContent.SampleId);
                    if (sample is not null) moistureContentDto.Sample = sample;
                }

                if (moistureContent.PreparationId is not null)
                {
                    var preparation = await _dataContext.Preparations.FindAsync(moistureContent.PreparationId);
                    if (preparation is not null) moistureContentDto.Preparation = preparation;
                }

                moistureContentDtoList.Add(moistureContentDto);
            }

            return Result<List<MoistureContentDto>>.Success(moistureContentDtoList);
        }
    }

}
