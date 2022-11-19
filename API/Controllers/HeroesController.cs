using API.Data;
using API.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class HeroesController : BaseApiController
    {

        private readonly IHeroRepository _repository;
        private readonly IMapper _mapper;

        public HeroesController(IHeroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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

        //[HttpPut]
        //public virtual async Task<IActionResult> Update([FromBody] HeroDto? heroes)
        //{
        //    return Ok(await _repository.Update(heroes));
        //}
    }
}