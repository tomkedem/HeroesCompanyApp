using API.DTOs;
using API.Entities;

namespace API.Data
{
    public interface ITrainerRepository
    {
        Task<TrainerDto> GetTrainByIdAsync(int id);
        Task<TrainerDto> GetTrainerByUsernameAsync(string username);
        Task<IEnumerable<TrainerDto>> GetTrainsAsync();
        void Update(Trainers trainer);
    }
}