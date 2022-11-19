using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var heroes = await _repository.GetHeroesAsync();

            var heroesToReturn = _mapper.Map<IEnumerable<HeroDto>>(heroes);

            return Ok(heroesToReturn);
        }

        [HttpGet("ByTrainerId/{trainerId}")]
        public async Task<ActionResult<IEnumerable<Heroes>>> getHeroesByTrainerId(int trainerId)
        {
            var heroes = await _repository.getHeroesByTrainerId(trainerId);

            var heroesToReturn = _mapper.Map<IEnumerable<HeroDto>>(heroes);

            return Ok(heroesToReturn);            
        }

        //[HttpPut]
        //public virtual async Task<IActionResult> Update([FromBody] HeroDto? heroes)
        //{
        //    return Ok(await _repository.Update(heroes));
        //}
    }
}