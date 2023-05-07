using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recruiting.ApplicationCore.Contract.Service;
using Recruiting.ApplicationCore.Model;

namespace Recruiting.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionServiceAsync _service;
        private readonly ILogger<SubmissionController> _logger;

        public SubmissionController(
            ISubmissionServiceAsync service,
            ILogger<SubmissionController> logger
        )
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddSubmission")]
        public async Task<IActionResult> AddSubmission(SubmissionModel model)
        {
            var result = await _service.AddSubmissionAsync(model);
            if (result == 0)
            {
                return BadRequest();
            }

            return Ok(new { message = "Submission Add sucessdully" });
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> getAllSubmission()
        {
            var result = await _service.GetAllSubmissionsAsync();
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _service.GetSubmissionByIdAsync(id);
            return Ok(entity);
        }

        [HttpDelete]
        public async Task<IActionResult> DeltetAsubmission(int id)
        {
            var result = await _service.DeleteSubmissionAsync(id);
            if (result == 0)
                return BadRequest();
            return Ok(new { message = "Submission deleted successfully." });
        }
    }
}
