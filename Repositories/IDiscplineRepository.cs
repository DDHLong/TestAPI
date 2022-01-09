using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.Repositories
{
    public interface IDiscplineRepository
    {
        Task<IEnumerable<Discpline>> Get();
        Task<Discpline> Get(int id);
        Task<Discpline> Create(Discpline discpline);
        Task Update(Discpline discpline);
        Task Delete(int id);
    }
}
