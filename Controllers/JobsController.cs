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
    public class JobsController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        public JobsController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Job>> GetJobs()
        {
            return await _jobRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Job>> GetJobs(int id)
        {
            return await _jobRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Job>> PostJobs([FromBody] Job job)
        {
            var newJob = await _jobRepository.Create(job);
            return CreatedAtAction(nameof(GetJobs), new { id = newJob.Id }, newJob);
        }

        [HttpPut]
        public async Task<ActionResult> PutJobs(int id, [FromBody] Job job)
        {
            if (id != job.Id)
            {
                return BadRequest();
            }

            await _jobRepository.Update(job);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var jobToDelete = await _jobRepository.Get(id);
            if (jobToDelete == null)
                return NotFound();

            await _jobRepository.Delete(jobToDelete.Id);
            return NoContent();
        }
    }
}
