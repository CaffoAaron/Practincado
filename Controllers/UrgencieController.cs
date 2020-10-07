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
    public class UrgencieController : ControllerBase
    {
        private readonly IUrgencieService _urgencieService;
        private readonly IMapper _mapper;

        public UrgencieController(IUrgencieService urgencieService, IMapper mapper)
        {
            _urgencieService = urgencieService;
            _mapper = mapper;
        }

        // GET: api/<UrgencieController>
        [HttpGet]
        public async Task<IEnumerable<UrgencieResource>> GetAllAsync()
        {
            var urgencies = await _urgencieService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Urgencie>,
                IEnumerable<UrgencieResource>>(urgencies);
            return resources;
        }

        // GET api/<UrgencieController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var urgencie = await _urgencieService.GetByIdAsync(id);
            var resources = _mapper.Map<Urgencie, UrgencieResource>(urgencie.Resource);
            return Ok(resources);
        }

        // POST api/<UrgencieController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUrgencieResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var urgencie = _mapper.Map<SaveUrgencieResource, Urgencie>(resource);

            var result = await _urgencieService.SaveAsync(urgencie);

            if (!result.Success)
                return BadRequest(result.Message);

            var urgencieResource = _mapper.Map<Urgencie, UrgencieResource>(result.Resource);

            return Ok(urgencieResource);
        }

        // PUT api/<UrgencieController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveUrgencieResource resource)
        {
            var guardian = _mapper.Map<SaveUrgencieResource, Urgencie>(resource);
            var result = await _urgencieService.UpdateAsync(id, guardian);

            if (!result.Success)
                return BadRequest(result.Message);
            var urgencieResource = _mapper.Map<Urgencie, UrgencieResource>(result.Resource);
            return Ok(urgencieResource);
        }

        // DELETE api/<UrgencieController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _urgencieService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var urgencieResource = _mapper.Map<Urgencie, UrgencieResource>(result.Resource);
            return Ok(urgencieResource);
        }
    }
}
