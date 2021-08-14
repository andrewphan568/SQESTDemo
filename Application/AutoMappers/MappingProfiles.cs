using API.DTOs;
using AutoMapper;
using Domain.Moisture;

namespace Application.AutoMappers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<MoistureContent, MoistureContentDto>();
        }

        
    }
}
