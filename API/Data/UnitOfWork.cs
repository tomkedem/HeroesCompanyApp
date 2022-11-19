using API.Interfaces;
using AutoMapper;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IHeroRepository HeroRepository => new HeroRepository(_context, _mapper);

        public ITrainerRepository TrainerRepository => new TrainerRepository(_context, _mapper);

        public async Task<bool> Complate()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool Haschange()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
