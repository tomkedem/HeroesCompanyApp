using API.Data;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        return Ok(await _repository.GetTrainsAsync());
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<TrainerDto>> GetTrainer(string username)
    {
      return await _repository.GetTrainerByUsernameAsync(username);
    }

  }
}