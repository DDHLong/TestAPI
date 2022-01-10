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
    public class JobJobTypeController : ControllerBase
    {
        private readonly IJobJobTypeRepository _jobJobTypeRepository;
        public JobJobTypeController(IJobJobTypeRepository jobJobTypeRepository)
        {
            _jobJobTypeRepository = jobJobTypeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<JobJobType>> GetJobJobType()
        {
            return await _jobJobTypeRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<JobJobType>> GetJobJobType(int id)
        {
            return await _jobJobTypeRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<JobJobType>> PostJobJobType([FromBody] JobJobType jobJobType)
        {
            var newJobJobType = await _jobJobTypeRepository.Create(jobJobType);
            return CreatedAtAction(nameof(GetJobJobType), new { id = newJobJobType.Id }, newJobJobType);
        }

        [HttpPut]
        public async Task<ActionResult> PutJobJobType(int id, [FromBody] JobJobType jobJobType)
        {
            if (id != jobJobType.Id)
            {
                return BadRequest();
            }

            await _jobJobTypeRepository.Update(jobJobType);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var jobJobTypeToDelete = await _jobJobTypeRepository.Get(id);
            if (jobJobTypeToDelete == null)
                return NotFound();

            await _jobJobTypeRepository.Delete(jobJobTypeToDelete.Id);
            return NoContent();
        }
    }
}
