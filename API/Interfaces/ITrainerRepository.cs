using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface ITrainerRepository
    {
        void Update(Trainers trainer);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Trainers>> GetTrainsAsync();
        Task<Trainers> GetTrainByIdAsync(int id);
        Task<Trainers> GetTrainByUsernameAsync(string username);



    }
}