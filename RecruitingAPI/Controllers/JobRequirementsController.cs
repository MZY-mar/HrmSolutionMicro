using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contract.Service;
using Recruiting.ApplicationCore.Model;

namespace Recruiting.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobRequirementsController : ControllerBase
    {
        private readonly IJobRequirementServiceAsync _jobRequirementService;

        public JobRequirementsController(IJobRequirementServiceAsync jobRequirementService)
        {
            _jobRequirementService = jobRequirementService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllJobRequirementsAsync()
        {
            var jobRequirements = await _jobRequirementService.GetAllJobRequirementsAsync();
            if (jobRequirements == null || !jobRequirements.Any())
                return NoContent();
            return Ok(jobRequirements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJobRequirementByIdAsync(int id)
        {
            var jobRequirement = await _jobRequirementService.GetJobRequirementByIdAsync(id);
            if (jobRequirement == null)
                return NotFound();
            return Ok(jobRequirement);
        }

        [HttpPost]
        [Route("AddJobRequirement")]
        public async Task<IActionResult> AddJobRequirementAsync(
            [FromBody] JobRequirementModel model
        )
        {
            var result = await _jobRequirementService.AddJobRequirementAsync(model);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateJobRequirementAsync(
            [FromBody] JobRequirementModel model
        )
        {
            var result = await _jobRequirementService.UpdateJobRequirementAsync(model);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobRequirementAsync(int id)
        {
            var result = await _jobRequirementService.DeleteJobRequirementAsync(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}
