using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class JobRepository : IJobRepository
    {
        public readonly TestContext _context;

        public JobRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<Job> Create(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return job;
        }

        public async Task Delete(int id)
        {
            var jobDelete = await _context.Jobs.FindAsync(id);
            _context.Jobs.Remove(jobDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Job>> Get()
        {
            return await _context.Jobs.ToListAsync();
        }

        public async Task<Job> Get(int id)
        {
            return await _context.Jobs.FindAsync(id);
        }

        public async Task Update(Job job)
        {
            _context.Entry(job).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
