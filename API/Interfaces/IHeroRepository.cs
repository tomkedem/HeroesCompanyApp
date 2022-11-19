using API.Entities;

namespace API.Data
{
    public interface IHeroRepository
    {
        Task<Heroes> GetHeroByIdAsync(int id);
        Task<Heroes> GetHeroByUsernameAsync(string username);
        Task<IEnumerable<Heroes>> GetHeroesAsync();
        Task<IEnumerable<Heroes>> getHeroesByTrainerId(int trainerId);
        Task<bool> SaveAllAsync();
        Task<Heroes> Update(Heroes Hero);
    }
}