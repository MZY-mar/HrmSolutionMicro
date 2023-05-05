using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contract.Service;
using Recruiting.ApplicationCore.Model;

namespace Recruiting.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionStatusController : ControllerBase
    {
        private readonly ISubmissionStatusServiceAsync _service;
        private readonly ILogger<SubmissionStatusController> _logger;

        public SubmissionStatusController(
            ISubmissionStatusServiceAsync service,
            ILogger<SubmissionStatusController> logger
        )
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllSubmissionStatuses()
        {
            var result = await _service.GetAllSubmissionStatusesAsync();
            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetSubmissionStatusById(int id)
        {
            var entity = await _service.GetSubmissionStatusByIdAsync(id);
            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(entity);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddSubmissionStatus(SubmissionStatusModel model)
        {
            var result = await _service.AddSubmissionStatusAsync(model);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok(new { message = "Submission status added successfully." });
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> UpdateSubmissionStatus(SubmissionStatusModel model)
        {
            var result = await _service.UpdateSubmissionStatusAsync(model);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok(new { message = "Submission status updated successfully." });
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteSubmissionStatus(int id)
        {
            var result = await _service.DeleteSubmissionStatusAsync(id);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok(new { message = "Submission status deleted successfully." });
        }
    }
}
