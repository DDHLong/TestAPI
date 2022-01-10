using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface ISpecialityRepository
    {
        Task<IEnumerable<Specialty>> Get();
        Task<Specialty> Get(int id);
        Task<Specialty> Create(Specialty speciality);
        Task Update(Specialty speciality);
        Task Delete(int id);
    }
}
