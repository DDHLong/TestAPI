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
    public class SpecialitiesController : ControllerBase
    {
        private readonly ISpecialityRepository _specialityRepository;
        public SpecialitiesController(ISpecialityRepository specialityRepository)
        {
            _specialityRepository = specialityRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Speciality>> GetSpecialities()
        {
            return await _specialityRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Speciality>> GetSpecialities(int id)
        {
            return await _specialityRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Speciality>> PostSpecialities([FromBody] Speciality speciality)
        {
            var newSpeciality = await _specialityRepository.Create(speciality);
            return CreatedAtAction(nameof(GetSpecialities), new { id = newSpeciality.SpecialityId }, newSpeciality);
        }

        [HttpPut]
        public async Task<ActionResult> PutSpecialities(int id, [FromBody] Speciality speciality)
        {
            if (id != speciality.SpecialityId)
            {
                return BadRequest();
            }

            await _specialityRepository.Update(speciality);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var specialityToDelete = await _specialityRepository.Get(id);
            if (specialityToDelete == null)
                return NotFound();

            await _specialityRepository.Delete(specialityToDelete.SpecialityId);
            return NoContent();
        }
    }
}
