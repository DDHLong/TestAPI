using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        public readonly TestContext _context;

        public CandidateRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<Candidate> Create(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync();

            return candidate;
        }

        public async Task Delete(int id)
        {
            var candidateDelete = await _context.Candidates.FindAsync(id);
            _context.Candidates.Remove(candidateDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Candidate>> Get()
        {
            return await _context.Candidates.ToListAsync();
        }

        public async Task<Candidate> Get(int id)
        {
            return await _context.Candidates.FindAsync(id);
        }

        public async Task Update(Candidate candidate)
        {
            _context.Entry(candidate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
