using AutoMapper;
using API.DTOs;
using API.Entities;


namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
          CreateMap<Heroes, HeroDto>();
          CreateMap<Trainers, TrainerDto>();
          CreateMap<HeroUpdateDto, Heroes>();

        }
  }
}