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
  [Authorize]
  public class HeroesController : BaseApiController
  {
    private readonly DataContext _context;
    public HeroesController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Heroes>>> GetHeroes()
    {
      return await _context.Heroes.ToListAsync();
    }
    // api/users/2
    [HttpGet("{id}")]
    public async Task<ActionResult<Heroes>> GetHeroes(int id)
    {
      return await _context.Heroes.FindAsync(id);
    }

  }
}