using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    //[Authorize]
    public class HeroesController : BaseApiController
    {
    
        private readonly IHeroRepository _herorepository;

        public HeroesController(IHeroRepository heroRepository)
        {
            _herorepository = heroRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Heroes>>> GetHeroes()
        {
            return Ok(await _herorepository.GetHeroesAsync());
        }
   
    
        [HttpGet("ByTrainerId/{trainerId}")]
        public async Task<ActionResult<IEnumerable<Heroes>>> getHeroesByTrainerId(int trainerId)
        {
            return Ok(await _herorepository.getHeroesByTrainerId(trainerId));
        }

    }
}