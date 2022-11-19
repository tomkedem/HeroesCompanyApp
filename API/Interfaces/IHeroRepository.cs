using API.DTOs;
using API.Entities;

namespace API.Data
{
    public interface IHeroRepository
    {
        Task<Heroes> GetHeroByIdAsync(int id);
        Task<HeroDto> GetHeroByUsernameAsync(string username);
        Task<IEnumerable<HeroDto>> GetHeroesAsync();
        Task<IEnumerable<HeroDto>> GetHeroesByTrainerId(int trainerId);
        Task<bool> SaveAllAsync();
        Task<HeroDto> Update(Heroes Hero);
    }
}