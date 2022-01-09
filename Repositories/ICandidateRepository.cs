using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> Get();
        Task<Candidate> Get(int id);
        Task<Candidate> Create(Candidate candidate);
        Task Update(Candidate candidate);
        Task Delete(int id);
    }
}
