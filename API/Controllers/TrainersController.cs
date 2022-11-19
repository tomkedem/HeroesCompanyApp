using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  [Authorize]
  public class TrainersController : BaseApiController
  {
    private readonly ITrainerRepository _trainerRepository;
    public TrainersController(ITrainerRepository trainerRepository)
    {
      _trainerRepository = trainerRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Trainers>>> GetTrainers()
    {
      return Ok(await _trainerRepository.GetTrainsAsync());
    }
    // api/username/tom
    [HttpGet("{username}")]
    public async Task<ActionResult<Trainers>> GetTrainers(string username)
    {
      return await _trainerRepository.GetTrainByUsernameAsync(username);
    }

  }
}