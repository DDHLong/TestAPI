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
    public class CandidateSpecialtyController : ControllerBase
    {
        private readonly ICandidateSpecialtyRepository _candidateSpecialtyRepository;
        public CandidateSpecialtyController(ICandidateSpecialtyRepository candidateSpecialtyRepository)
        {
            _candidateSpecialtyRepository = candidateSpecialtyRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CandidateSpecialty>> GetCandidateSpecialty()
        {
            return await _candidateSpecialtyRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateSpecialty>> GetCandidateSpecialty(int id)
        {
            return await _candidateSpecialtyRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<CandidateSpecialty>> PostCandidateSpecialty([FromBody] CandidateSpecialty candidateSpecialty)
        {
            var newCandidateSpecialty = await _candidateSpecialtyRepository.Create(candidateSpecialty);
            return CreatedAtAction(nameof(GetCandidateSpecialty), new { id = newCandidateSpecialty.Id }, newCandidateSpecialty);
        }

        [HttpPut]
        public async Task<ActionResult> PutCandidateSpecialty(int id, [FromBody] CandidateSpecialty candidateSpecialty)
        {
            if (id != candidateSpecialty.Id)
            {
                return BadRequest();
            }

            await _candidateSpecialtyRepository.Update(candidateSpecialty);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var candidateSpecialtyToDelete = await _candidateSpecialtyRepository.Get(id);
            if (candidateSpecialtyToDelete == null)
                return NotFound();

            await _candidateSpecialtyRepository.Delete(candidateSpecialtyToDelete.Id);
            return NoContent();
        }
    }
}
