using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helper
{
  public class AutoMapperProfiles : Profile
    {
    protected AutoMapperProfiles()
    {
      CreateMap<Heroes, HeroDto>();
      //CreateMap<Trainers, TrainerDto>();
      
    }
  }
}