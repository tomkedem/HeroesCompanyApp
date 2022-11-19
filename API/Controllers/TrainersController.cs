using API.Data;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
  public class TrainersController : BaseApiController
  {
    private readonly IUnitOfWork _unitofwork;

     public TrainersController(IUnitOfWork unitOfWork)
     {
        _unitofwork = unitOfWork;
     }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainerDto>>> GetTrainers()
    {
        return Ok(await _unitofwork.TrainerRepository.GetTrainsAsync());
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<TrainerDto>> GetTrainer(string username)
    {
      return await _unitofwork.TrainerRepository.GetTrainerByUsernameAsync(username);
    }

  }
}