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
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        public CandidatesController(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Candidate>> GetCandidates()
        {
            return await _candidateRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidates(int id)
        {
            return await _candidateRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Candidate>> PostCandidates([FromBody] Candidate candidate)
        {
            var newCandidate = await _candidateRepository.Create(candidate);
            return CreatedAtAction(nameof(GetCandidates), new { id = newCandidate.Id }, newCandidate);
        }

        [HttpPut]
        public async Task<ActionResult> PutCandidates(int id, [FromBody] Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }

            await _candidateRepository.Update(candidate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var candidateToDelete = await _candidateRepository.Get(id);
            if (candidateToDelete == null)
                return NotFound();

            await _candidateRepository.Delete(candidateToDelete.Id);
            return NoContent();
        }
    }
}
