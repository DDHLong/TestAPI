using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<Job>> Get();
        Task<Job> Get(int id);
        Task<Job> Create(Job job);
        Task Update(Job job);
        Task Delete(int id);
    }
}
