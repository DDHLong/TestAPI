using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface ICandidateJobTypeRepository
    {
        Task<IEnumerable<CandidateJobType>> Get();
        Task<CandidateJobType> Get(int id);
        Task<CandidateJobType> Create(CandidateJobType candidateJobType);
        Task Update(CandidateJobType candidateJobType);
        Task Delete(int id);
    }
}
