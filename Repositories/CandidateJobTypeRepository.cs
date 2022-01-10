using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class CandidateJobTypeRepository : ICandidateJobTypeRepository
    {
        public readonly TestContext _context;

        public CandidateJobTypeRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<CandidateJobType> Create(CandidateJobType candidateJobType)
        {
            _context.CandidateJobTypes.Add(candidateJobType);
            await _context.SaveChangesAsync();

            return candidateJobType;
        }

        public async Task Delete(int id)
        {
            var candidateJobTypeDelete = await _context.CandidateJobTypes.FindAsync(id);
            _context.CandidateJobTypes.Remove(candidateJobTypeDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CandidateJobType>> Get()
        {
            return await _context.CandidateJobTypes.ToListAsync();
        }

        public async Task<CandidateJobType> Get(int id)
        {
            return await _context.CandidateJobTypes.FindAsync(id);
        }

        public async Task Update(CandidateJobType candidateJobType)
        {
            _context.Entry(candidateJobType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
