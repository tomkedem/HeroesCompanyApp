using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{

    public class HeroRepository : IHeroRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public HeroRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Heroes> GetHeroByIdAsync(Guid id)
        {
            return await _context.Heroes
                            
                    .SingleOrDefaultAsync(x => x.Id == id);

        }

        public async Task<HeroDto> GetHeroByUsernameAsync(string username)
        {
            return await _context.Heroes
                    .Where(x => x.FullName == username)
                    .ProjectTo<HeroDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync();

        }
        public async Task<IEnumerable<HeroDto>> GetHeroesByTrainerId(int trainerId)
        {
            return await _context.Heroes
                    .Where(x => x.TrainerId == trainerId)
                    .OrderBy(x => x.CurrentPower)
                    .ProjectTo<HeroDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

        }
        public async Task<IEnumerable<HeroDto>> GetHeroesAsync()
        {
            return await _context.Heroes
                    .OrderBy(o => o.CurrentPower)
                    .ProjectTo<HeroDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public void Update(Heroes heroes)
        {
            _context.Entry(heroes).State = EntityState.Modified;
        }
    }

}