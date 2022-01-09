using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public class DiscplineRepository : IDiscplineRepository
    {
        public readonly TestContext _context;

        public DiscplineRepository(TestContext context)
        {
            _context = context;
        }

        public async Task<Discpline> Create(Discpline discpline)
        {
            _context.Discplines.Add(discpline);
            await _context.SaveChangesAsync();

            return discpline;
        }

        public async Task Delete(int id)
        {
            var discplineDelete = await _context.Discplines.FindAsync(id);
            _context.Discplines.Remove(discplineDelete);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Discpline>> Get()
        {
            return await _context.Discplines.ToListAsync();
        }

        public async Task<Discpline> Get(int id)
        {
            return await _context.Discplines.FindAsync(id);
        }

        public async Task Update(Discpline discpline)
        {
            _context.Entry(discpline).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
