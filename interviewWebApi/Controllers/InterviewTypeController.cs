using System.Collections.Generic;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Service;
using Interview.ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace interviewWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewTypeController : ControllerBase
    {
        private readonly IInterviewTypeServiceAsync _interviewTypeService;

        public InterviewTypeController(IInterviewTypeServiceAsync interviewTypeService)
        {
            _interviewTypeService = interviewTypeService;
        }

        [HttpGet]
        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypes()
        {
            return await _interviewTypeService.GetAllInterviewTypesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InterviewTypeResponseModel>> GetInterviewTypeById(int id)
        {
            var interviewType = await _interviewTypeService.GetInterviewTypeByIdAsync(id);

            if (interviewType == null)
            {
                return NotFound();
            }

            return interviewType;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddInterviewType(InterviewTypeRequestModel model)
        {
            var id = await _interviewTypeService.AddInterviewTypeAsync(model);

            if (id == 0)
            {
                return BadRequest();
            }

            return id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateInterviewType(
            int id,
            InterviewTypeRequestModel model
        )
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var rowsAffected = await _interviewTypeService.UpdateInterviewTypeAsync(model);

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return rowsAffected;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteInterviewType(int id)
        {
            var rowsAffected = await _interviewTypeService.DeleteInterviewTypeAsync(id);

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return rowsAffected;
        }
    }
}
