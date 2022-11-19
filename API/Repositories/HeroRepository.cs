using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{

    public class HeroRepository : IHeroRepository
    {
        private readonly DataContext _context;
        public HeroRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Heroes> GetHeroByIdAsync(int id)
        {
            return await _context.Heroes.FindAsync(id);
        }

        public async Task<Heroes> GetHeroByUsernameAsync(string username)
        {
            return await _context.Heroes.SingleOrDefaultAsync(x => x.FullName == username);
        }
        public async Task<IEnumerable<Heroes>> getHeroesByTrainerId(int trainerId)
        {
            return await _context.Heroes.Where(o => o.TrainerId == trainerId)
                                        .OrderBy(o => o.CurrentPower).ToListAsync();
        }
        public async Task<IEnumerable<Heroes>> GetHeroesAsync()
        {
            return await _context.Heroes.OrderBy(o => o.CurrentPower).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public Task<Heroes> Update(Heroes Hero)
        {
            _context.Entry(Hero).State = EntityState.Modified;
            return null;
        }
    }

}