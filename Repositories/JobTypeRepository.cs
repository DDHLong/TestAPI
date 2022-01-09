using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class JobTypeRepository : IJobTypeRepository
    {
        public readonly TestContext _context;

        public JobTypeRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<JobType> Create(JobType jobType)
        {
            _context.JobTypes.Add(jobType);
            await _context.SaveChangesAsync();

            return jobType;
        }

        public async Task Delete(int id)
        {
            var JobTypeDelete = await _context.JobTypes.FindAsync(id);
            _context.JobTypes.Remove(JobTypeDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobType>> Get()
        {
            return await _context.JobTypes.ToListAsync();
        }

        public async Task<JobType> Get(int id)
        {
            return await _context.JobTypes.FindAsync(id);
        }

        public async Task Update(JobType jobType)
        {
            _context.Entry(jobType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
