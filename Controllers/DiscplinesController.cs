using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using TestAPI.Repositories;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscplinesController : ControllerBase
    {
        private readonly IDiscplineRepository _discplineRepository;
        public DiscplinesController(IDiscplineRepository discplineRepository)
        {
            _discplineRepository = discplineRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Discpline>> GetDiscplines()
        {
            return await _discplineRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Discpline>> GetDiscplines(int id)
        {
            return await _discplineRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Discpline>> PostDiscplines([FromBody] Discpline discpline)
        {
            var newDiscpline = await _discplineRepository.Create(discpline);
            return CreatedAtAction(nameof(GetDiscplines), new { id = newDiscpline.DiscplineId }, newDiscpline);
        }

        [HttpPut]
        public async Task<ActionResult> PutDiscplines(int id, [FromBody] Discpline discpline)
        {
            if (id != discpline.DiscplineId)
            {
                return BadRequest();
            }

            await _discplineRepository.Update(discpline);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var discplineToDelete = await _discplineRepository.Get(id);
            if (discplineToDelete == null)
                return NotFound();

            await _discplineRepository.Delete(discplineToDelete.DiscplineId);
            return NoContent();
        }
    }
}
