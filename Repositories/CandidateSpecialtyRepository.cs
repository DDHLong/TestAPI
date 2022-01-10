using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class CandidateSpecialtyRepository : ICandidateSpecialtyRepository
    {
        public readonly TestContext _context;

        public CandidateSpecialtyRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<CandidateSpecialty> Create(CandidateSpecialty candidateSpecialty)
        {
            var candidate = await (from c in _context.CandidateSpecialties
                                   where
                                   c.CandidateId == candidateSpecialty.CandidateId 
                                   select c).ToListAsync();
            if (candidate.Count < 2)
            {
                _context.CandidateSpecialties.Add(candidateSpecialty);
                await _context.SaveChangesAsync();
                return candidateSpecialty;
            }
            return candidateSpecialty;
        }

        public async Task Delete(int id)
        {
            var candidateSpecialtyDelete = await _context.CandidateSpecialties.FindAsync(id);
            _context.CandidateSpecialties.Remove(candidateSpecialtyDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CandidateSpecialty>> Get()
        {
            return await _context.CandidateSpecialties.ToListAsync();
        }

        public async Task<CandidateSpecialty> Get(int id)
        {
            return await _context.CandidateSpecialties.FindAsync(id);
        }

        public async Task Update(CandidateSpecialty candidateSpecialty)
        {
            _context.Entry(candidateSpecialty).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
