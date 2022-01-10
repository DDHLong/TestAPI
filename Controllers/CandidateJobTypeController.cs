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
    public class CandidateJobTypeController : ControllerBase
    {
        private readonly ICandidateJobTypeRepository _candidateJobTypeRepository;
        public CandidateJobTypeController(ICandidateJobTypeRepository candidateJobTypeRepository)
        {
            _candidateJobTypeRepository = candidateJobTypeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CandidateJobType>> GetCandidateJobType()
        {
            return await _candidateJobTypeRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateJobType>> GetCandidateJobType(int id)
        {
            return await _candidateJobTypeRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<CandidateJobType>> PostCandidateJobType([FromBody] CandidateJobType candidateJobType)
        {
            var newCandidateJobType = await _candidateJobTypeRepository.Create(candidateJobType);
            return CreatedAtAction(nameof(GetCandidateJobType), new { id = newCandidateJobType.Id }, newCandidateJobType);
        }

        [HttpPut]
        public async Task<ActionResult> PutCandidateJobType(int id, [FromBody] CandidateJobType candidateJobType)
        {
            if (id != candidateJobType.Id)
            {
                return BadRequest();
            }

            await _candidateJobTypeRepository.Update(candidateJobType);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var candidateJobTypeToDelete = await _candidateJobTypeRepository.Get(id);
            if (candidateJobTypeToDelete == null)
                return NotFound();

            await _candidateJobTypeRepository.Delete(candidateJobTypeToDelete.Id);
            return NoContent();
        }
    }
}
