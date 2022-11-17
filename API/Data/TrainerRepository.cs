using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class TrainerRepository : ITrainerRepository
  {
    private readonly DataContext _context;
    public TrainerRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<Trainers> GetTrainByIdAsync(int id)
    {
      return await _context.Trainers.FindAsync(id);
    }

    public async Task<Trainers> GetTrainByUsernameAsync(string username)
    {
      return await _context.Trainers.SingleOrDefaultAsync(x => x.UserName == username);
    }

    public async Task<IEnumerable<Trainers>> GetTrainsAsync()
    {
      return await _context.Trainers.OrderBy(o => o.KnownAs).ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public void Update(Trainers trainer)
    {
      _context.Entry(trainer).State = EntityState.Modified;
    }
  }
}