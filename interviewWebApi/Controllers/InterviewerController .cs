using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Service;
using Interview.ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace interviewWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerServiceAsync _interviewerService;

        public InterviewerController(IInterviewerServiceAsync interviewerService)
        {
            _interviewerService = interviewerService;
        }

        [HttpGet]
        [Route("GetAllInterviewers")]
        public async Task<
            ActionResult<IEnumerable<InterviewerResponseModel>>
        > GetAllInterviewersAsync()
        {
            var interviewers = await _interviewerService.GetAllInterviewersAsync();
            if (interviewers == null)
            {
                return NotFound();
            }
            return Ok(interviewers);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<InterviewerResponseModel>> GetInterviewerByIdAsync(int id)
        {
            var interviewer = await _interviewerService.GetInterviewerByIdAsync(id);
            if (interviewer == null)
            {
                return NotFound();
            }
            return Ok(interviewer);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddInterviewerAsync(
            [FromBody] InterviewerRequestModel model
        )
        {
            var result = await _interviewerService.AddInterviewerAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateInterviewerAsync(
            int id,
            InterviewerRequestModel model
        )
        {
            model.Id = id;
            var result = await _interviewerService.UpdateInterviewerAsync(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteInterviewerAsync(int id)
        {
            var result = await _interviewerService.DeleteInterviewerAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
