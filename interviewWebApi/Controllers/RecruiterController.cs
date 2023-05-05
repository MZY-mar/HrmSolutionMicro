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
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterServiceAsync _recruiterService;

        public RecruiterController(IRecruiterServiceAsync recruiterService)
        {
            _recruiterService = recruiterService;
        }

        [HttpGet]
        public async Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiters()
        {
            return await _recruiterService.GetAllRecruitersAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecruiterResponseModel>> GetRecruiterById(int id)
        {
            var recruiter = await _recruiterService.GetRecruiterByIdAsync(id);

            if (recruiter == null)
            {
                return NotFound();
            }

            return recruiter;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddRecruiter(RecruiterRequestModel model)
        {
            var id = await _recruiterService.AddRecruiterAsync(model);

            if (id == 0)
            {
                return BadRequest();
            }

            return id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateRecruiter(int id, RecruiterRequestModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var rowsAffected = await _recruiterService.UpdateRecruiterAsync(model);

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return rowsAffected;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteRecruiter(int id)
        {
            var rowsAffected = await _recruiterService.DeleteRecruiterAsync(id);

            if (rowsAffected == 0)
            {
                return NotFound();
            }

            return rowsAffected;
        }
    }
}
