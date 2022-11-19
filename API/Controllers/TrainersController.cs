using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [Authorize]
  public class TrainersController : BaseApiController
  {
    private readonly ITrainerRepository _repository;
    private readonly IMapper _mapper;

    public TrainersController(ITrainerRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainerDto>>> GetTrainers()
    {
      var trainers = await _repository.GetTrainsAsync();

      var trainersToReturn = _mapper.Map<IEnumerable<TrainerDto>>(trainers);

      return Ok(trainersToReturn);

    }

    [HttpGet("{username}")]
    public async Task<ActionResult<TrainerDto>> GetTrainer(string username)
    {
      var trainers = await _repository.GetTrainByUsernameAsync(username);

      var trainersToReturn = _mapper.Map<TrainerDto>(trainers);

      return Ok(trainersToReturn);

    }

  }
}