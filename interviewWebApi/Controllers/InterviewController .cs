using Interview.ApplicationCore.Contract.Service;
using Interview.ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace interviewWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewServiceAsync _interviewService;

        public InterviewController(IInterviewServiceAsync interviewService)
        {
            _interviewService = interviewService;
        }

        [HttpGet]
        [Route("GetAllInterView")]
        public async Task<ActionResult<IEnumerable<InterviewResponseModel>>> GetAllInterviewsAsync()
        {
            var interviews = await _interviewService.GetAllInterviewsAsync();
            if (interviews == null)
            {
                return NotFound();
            }
            return Ok(interviews);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<InterviewResponseModel>> GetInterviewByIdAsync(int id)
        {
            var interview = await _interviewService.GetInterviewByIdAsync(id);
            if (interview == null)
            {
                return NotFound();
            }
            return Ok(interview);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddInterviewAsync(
            [FromBody] InterviewRequestModel model
        )
        {
            var result = await _interviewService.AddInterviewAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateInterviewAsync(
            int id,
            InterviewRequestModel model
        )
        {
            model.Id = id;
            var result = await _interviewService.UpdateInterviewAsync(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteInterviewAsync(int id)
        {
            var result = await _interviewService.DeleteInterviewAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetCandidates")]
        public async Task<IActionResult> GetCandidate()
        {
            string str = "http://host.docker.internal:8082/api/Candidate/GetAll";
            HttpClient client = new HttpClient();
            var candidateResponse = await client.GetFromJsonAsync<IEnumerable<CandidateModel>>(str);
            return Ok(candidateResponse);
        }
    }
}
