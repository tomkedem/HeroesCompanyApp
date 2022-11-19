using API.Data;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    //[Authorize]
    public class HeroesController : BaseApiController
    {

        private readonly IHeroRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITrainerRepository _userRepository;

        public HeroesController(IHeroRepository repository, IMapper mapper, ITrainerRepository userRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet]       
        public async Task<ActionResult<IEnumerable<HeroDto>>> GetHeroes()
        {       
            return Ok(await _repository.GetHeroesAsync());
        }

        [HttpGet("ByTrainerId/{trainerId}")]
        public async Task<ActionResult<IEnumerable<HeroDto>>> GetHeroesByTrainerId(int trainerId)
        {
            return Ok(await _repository.GetHeroesByTrainerId(trainerId));
        }
        
       
        [HttpPut("UpdateHero")]
        public async Task<ActionResult<HeroDto>> UpdateHero(HeroUpdateDto heroUpdateDto)
        {
            int totalTrainingToday = 0;
         //   var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var hero = await _repository.GetHeroByIdAsync(heroUpdateDto.Id);
            totalTrainingToday = hero.TotalTrainingToday;
            totalTrainingToday += 1;
            hero.TotalTrainingToday = totalTrainingToday;
            heroUpdateDto.TotalTrainingToday = totalTrainingToday;
            heroUpdateDto.TrainingDate= DateTime.Now;

          
            Random r = new Random();

            float cur = hero.CurrentPower;
            var result = ((float)cur / 100) * 10;
            double rDouble = r.NextDouble() * result;
            float last = cur + (float)rDouble;
            heroUpdateDto.CurrentPower = float.Parse(last.ToString("n2"));

            _mapper.Map(heroUpdateDto, hero);
            _repository.Update(hero);

            await _repository.SaveAllAsync();
            var hero1 = await _repository.GetHeroByIdAsync(heroUpdateDto.Id);
          
            HeroDto heroDto = new HeroDto();
            _mapper.Map(hero1, heroDto);
            return heroDto;            
           
        }
    }
}