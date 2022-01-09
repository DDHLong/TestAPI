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
    public class JobTypesController : ControllerBase
    {
        private readonly IJobTypeRepository _jobTypeRepository;
        public JobTypesController(IJobTypeRepository jobTypeRepository)
        {
            _jobTypeRepository = jobTypeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<JobType>> GetJobTypes()
        {
            return await _jobTypeRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobType>> GetJobTypes(int id)
        {
            return await _jobTypeRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<JobType>> PostJobTypes([FromBody] JobType jobType)
        {
            var newJobType = await _jobTypeRepository.Create(jobType);
            return CreatedAtAction(nameof(GetJobTypes), new { id = newJobType.JobTypeId }, newJobType);
        }

        [HttpPut]
        public async Task<ActionResult> PutJobTypes(int id, [FromBody] JobType jobType)
        {
            if (id != jobType.JobTypeId)
            {
                return BadRequest();
            }

            await _jobTypeRepository.Update(jobType);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var jobTypeToDelete = await _jobTypeRepository.Get(id);
            if (jobTypeToDelete == null)
                return NotFound();

            await _jobTypeRepository.Delete(jobTypeToDelete.JobTypeId);
            return NoContent();
        }
    }
}
