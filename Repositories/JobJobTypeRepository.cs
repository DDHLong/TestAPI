using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class JobJobTypeRepository : IJobJobTypeRepository
    {
        public readonly TestContext _context;

        public JobJobTypeRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<JobJobType> Create(JobJobType jobJobType)
        {
            _context.JobJobTypes.Add(jobJobType);
            await _context.SaveChangesAsync();

            return jobJobType;
        }

        public async Task Delete(int id)
        {
            var jobJobTypeDelete = await _context.JobJobTypes.FindAsync(id);
            _context.JobJobTypes.Remove(jobJobTypeDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<JobJobType>> Get()
        {
            return await _context.JobJobTypes.ToListAsync();
        }

        public async Task<JobJobType> Get(int id)
        {
            return await _context.JobJobTypes.FindAsync(id);
        }

        public async Task Update(JobJobType jobJobType)
        {
            _context.Entry(jobJobType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
