using API.DTOs;
using AutoMapper;
using Domain.Moisture;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

        public IMapper Mapper { get; }

        public async Task<Result<MoistureContentDto>> Handle(GetMoistureContentQuery request, CancellationToken cancellationToken)
        {
             var moistureContent = await _dataContext.MoistureContents.FindAsync(request.Id);
            if (moistureContent is null)  return Result<MoistureContentDto>.Failure("Id Not Found");

            var moistureContentDto = new MoistureContentDto();
            _mapper.Map(moistureContent, moistureContentDto);

            // temporarily use this way to get child objects in moistureContent
            // will refactor after sovling the "seed owned types" issue when migrating database

         /*   if (moistureContent.ProjectId is not null) {
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
*/
            return Result<MoistureContentDto>.Success(moistureContentDto);

        }
    }
}
