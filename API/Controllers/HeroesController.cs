using API.Data;
using API.DTOs;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace API.Controllers
{
  //[Authorize]
  public class HeroesController : BaseApiController
  {
    private readonly IUnitOfWork _unitofwork;
    private readonly IMapper _mapper;

    private readonly ILogger<HeroesController> _logger;
    public HeroesController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<HeroesController> logger)
    {
      _logger = logger;
      _unitofwork = unitOfWork;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<HeroDto>>> GetHeroes()
    {
      this._logger.LogInformation("|Log || Testing");
      return Ok(await _unitofwork.HeroRepository.GetHeroesAsync());
    }

    [HttpGet("ByTrainerId/{trainerId}")]
    public async Task<ActionResult<IEnumerable<HeroDto>>> GetHeroesByTrainerId(int trainerId)
    {       
      return Ok(await _unitofwork.HeroRepository.GetHeroesByTrainerId(trainerId));
    }


    [HttpPut("UpdateHero")]
    public async Task<ActionResult<HeroDto>> UpdateHero(HeroUpdateDto heroUpdateDto)
    {
      int totalTrainingToday = 0;
      //   var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var hero = await _unitofwork.HeroRepository.GetHeroByIdAsync(heroUpdateDto.Id);
      totalTrainingToday = heroUpdateDto.TotalTrainingToday;
      totalTrainingToday += 1;
      hero.TotalTrainingToday = totalTrainingToday;
      heroUpdateDto.TotalTrainingToday = totalTrainingToday;
      heroUpdateDto.TrainingDate = DateTime.Now;


      Random r = new Random();

      float cur = hero.CurrentPower;
      var result = ((float)cur / 100) * 10;
      double rDouble = r.NextDouble() * result;
      float last = cur + (float)rDouble;
      heroUpdateDto.CurrentPower = float.Parse(last.ToString("n2"));

      _mapper.Map(heroUpdateDto, hero);
      _unitofwork.HeroRepository.Update(hero);

      await _unitofwork.Complate();
      var hero1 = await _unitofwork.HeroRepository.GetHeroByIdAsync(heroUpdateDto.Id);

      HeroDto heroDto = new HeroDto();
      _mapper.Map(hero1, heroDto);
      return heroDto;

    }
  }
}