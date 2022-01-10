using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface IJobJobTypeRepository
    {
        Task<IEnumerable<JobJobType>> Get();
        Task<JobJobType> Get(int id);
        Task<JobJobType> Create(JobJobType jobJobType);
        Task Update(JobJobType jobJobType);
        Task Delete(int id);
    }
}
