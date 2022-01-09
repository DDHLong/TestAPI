using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface ISpecialityRepository
    {
        Task<IEnumerable<Speciality>> Get();
        Task<Speciality> Get(int id);
        Task<Speciality> Create(Speciality speciality);
        Task Update(Speciality speciality);
        Task Delete(int id);
    }
}
