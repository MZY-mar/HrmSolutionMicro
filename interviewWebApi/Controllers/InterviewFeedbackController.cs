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
    public class InterviewFeedbackController : ControllerBase
    {
        private readonly IInterviewFeedbackServiceAsync _interviewFeedbackService;

        public InterviewFeedbackController(IInterviewFeedbackServiceAsync interviewFeedbackService)
        {
            _interviewFeedbackService = interviewFeedbackService;
        }

        [HttpGet]
        [Route("GetAllInterviewFeedback")]
        public async Task<
            ActionResult<IEnumerable<InterviewFeedbackResponseModel>>
        > GetAllInterviewFeedbackAsync()
        {
            var interviewFeedback = await _interviewFeedbackService.GetAllInterviewFeedbacksAsync();
            if (interviewFeedback == null)
            {
                return NotFound();
            }
            return Ok(interviewFeedback);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<
            ActionResult<InterviewFeedbackResponseModel>
        > GetInterviewFeedbackByIdAsync(int id)
        {
            var interviewFeedback = await _interviewFeedbackService.GetInterviewFeedbackByIdAsync(
                id
            );
            if (interviewFeedback == null)
            {
                return NotFound();
            }
            return Ok(interviewFeedback);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddInterviewFeedbackAsync(
            [FromBody] InterviewFeedbackRequestModel model
        )
        {
            var result = await _interviewFeedbackService.AddInterviewFeedbackAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateInterviewFeedbackAsync(
            int id,
            InterviewFeedbackRequestModel model
        )
        {
            model.Id = id;
            var result = await _interviewFeedbackService.UpdateInterviewFeedbackAsync(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteInterviewFeedbackAsync(int id)
        {
            var result = await _interviewFeedbackService.DeleteInterviewFeedbackAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
