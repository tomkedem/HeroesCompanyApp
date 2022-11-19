using API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IHeroRepository HeroRepository {get;}

        ITrainerRepository TrainerRepository {get;}

        Task<bool> Complate();
        bool Haschange();
    }
}