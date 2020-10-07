using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practincado.Domain.Models;
using Practincado.Domain.Services;
using Practincado.Extensions;
using Practincado.Resources;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practincado.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GuardianController : ControllerBase
    {
        private readonly IGuardianService _guardianService;
        private readonly IMapper _mapper;

        public GuardianController(IGuardianService guardianService, IMapper mapper)
        {
            _guardianService = guardianService;
            _mapper = mapper;
        }

        // GET: api/<GuardianController>
        [HttpGet]
        public async Task<IEnumerable<GuardianResource>> GetAllAsync()
        {
            var guardians = await _guardianService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Guardian>,
                IEnumerable<GuardianResource>>(guardians);
            return resources;
        }

        // GET api/<GuardianController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var guardian = await _guardianService.GetByIdAsync(id);
            var resources = _mapper.Map<Guardian, GuardianResource>(guardian.Resource);
            return Ok(resources);
        }

        // POST api/<GuardianController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveGuardianResources resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var guardian = _mapper.Map<SaveGuardianResources, Guardian>(resource);

            var result = await _guardianService.SaveAsync(guardian);

            if (!result.Success)
                return BadRequest(result.Message);

            var guardiaResource = _mapper.Map<Guardian, GuardianResource>(result.Resource);

            return Ok(guardiaResource);
        }

        // PUT api/<GuardianController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveGuardianResources resource)
        {
            var guardian = _mapper.Map<SaveGuardianResources, Guardian>(resource);
            var result = await _guardianService.UpdateAsync(id, guardian);

            if (!result.Success)
                return BadRequest(result.Message);
            var categoryResource = _mapper.Map<Guardian, GuardianResource>(result.Resource);
            return Ok(categoryResource);
        }

        // DELETE api/<GuardianController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _guardianService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var categoryResource = _mapper.Map<Guardian, GuardianResource>(result.Resource);
            return Ok(categoryResource);
        }

    }
     
    
}
