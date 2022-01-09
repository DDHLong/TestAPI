using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        public readonly TestContext _context;

        public ApplicantRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<Applicant> Create(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();

            return applicant;
        }

        public async Task Delete(int id)
        {
            var applicantDelete = await _context.Applicants.FindAsync(id);
            _context.Applicants.Remove(applicantDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Applicant>> Get()
        {
            return await _context.Applicants.ToListAsync();
        }

        public async Task<Applicant> Get(int id)
        {
            return await _context.Applicants.FindAsync(id);
        }

        public async Task Update(Applicant applicant)
        {
            _context.Entry(applicant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
