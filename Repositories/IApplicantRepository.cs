using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface IApplicantRepository
    {
        Task<IEnumerable<Applicant>> Get();
        Task<Applicant> Get(int id);
        Task<Applicant> Create(Applicant applicant);
        Task Update(Applicant applicant);
        Task Delete(int id);
    }
}
