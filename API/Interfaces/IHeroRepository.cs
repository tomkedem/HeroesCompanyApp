using API.DTOs;
using API.Entities;

namespace API.Data
{
    public interface IHeroRepository
    {
        Task<Heroes> GetHeroByIdAsync(Guid id);
        Task<HeroDto> GetHeroByUsernameAsync(string username);
        Task<IEnumerable<HeroDto>> GetHeroesAsync();
        Task<IEnumerable<HeroDto>> GetHeroesByTrainerId(int trainerId);
        
        void Update(Heroes heroes);
    }
}