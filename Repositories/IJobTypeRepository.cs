using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface IJobTypeRepository
    {
        Task<IEnumerable<JobType>> Get();
        Task<JobType> Get(int id);
        Task<JobType> Create(JobType jobType);
        Task Update(JobType jobType);
        Task Delete(int id);
    }
}
