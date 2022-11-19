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
    public class TrainerRepository : ITrainerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public TrainerRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TrainerDto> GetTrainByIdAsync(int id)
        {
            return await _context.Trainers
                    .Where(x => x.Id == id)
                    .ProjectTo<TrainerDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync();
        }
        public async Task<TrainerDto> GetTrainerByUsernameAsync(string username)
        {
            return await _context.Trainers
                    .Where(x => x.UserName == username)
                    .ProjectTo<TrainerDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<TrainerDto>> GetTrainsAsync()
        {
            return await _context.Trainers
                        .OrderBy(o => o.KnownAs)
                        .ProjectTo<TrainerDto>(_mapper.ConfigurationProvider)
                        .ToListAsync();
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