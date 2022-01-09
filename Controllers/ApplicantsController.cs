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
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantRepository _applicantRepository;
        public ApplicantsController(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Applicant>> GetApplicants()
        {
            return await _applicantRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Applicant>> GetApplicants(int id)
        {
            return await _applicantRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Applicant>> PostApplicants([FromBody] Applicant applicant)
        {
            var newApplicant = await _applicantRepository.Create(applicant);
            return CreatedAtAction(nameof(GetApplicants), new { id = newApplicant.Id }, newApplicant);
        }

        [HttpPut]
        public async Task<ActionResult> PutApplicants(int id, [FromBody] Applicant applicant)
        {
            if (id != applicant.Id)
            {
                return BadRequest();
            }

            await _applicantRepository.Update(applicant);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var applicantToDelete = await _applicantRepository.Get(id);
            if (applicantToDelete == null)
                return NotFound();

            await _applicantRepository.Delete(applicantToDelete.Id);
            return NoContent();
        }
    }
}
