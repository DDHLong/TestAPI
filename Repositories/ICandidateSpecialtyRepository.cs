using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface ICandidateSpecialtyRepository
    {
        Task<IEnumerable<CandidateSpecialty>> Get();
        Task<CandidateSpecialty> Get(int id);
        Task<CandidateSpecialty> Create(CandidateSpecialty candidateSpecialty);
        Task Update(CandidateSpecialty candidateSpecialty);
        Task Delete(int id);
    }
}
