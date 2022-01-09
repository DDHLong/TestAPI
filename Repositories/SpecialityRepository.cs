using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class SpecialityRepository : ISpecialityRepository
    {
        public readonly TestContext _context;

        public SpecialityRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<Speciality> Create(Speciality speciality)
        {
            _context.Specialities.Add(speciality);
            await _context.SaveChangesAsync();

            return speciality;
        }

        public async Task Delete(int id)
        {
            var SpecialityDelete = await _context.Specialities.FindAsync(id);
            _context.Specialities.Remove(SpecialityDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Speciality>> Get()
        {
            return await _context.Specialities.ToListAsync();
        }

        public async Task<Speciality> Get(int id)
        {
            return await _context.Specialities.FindAsync(id);
        }

        public async Task Update(Speciality speciality)
        {
            _context.Entry(speciality).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
