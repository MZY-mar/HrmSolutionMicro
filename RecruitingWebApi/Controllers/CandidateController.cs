using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Contract.Service;
using Recruiting.ApplicationCore.Model;

namespace Recruiting.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly ICandidateServiceAsync _service;

        public CandidateController(
            ICandidateServiceAsync serviceAsync,
            ILogger<CandidateController> logger
        )
        {
            _service = serviceAsync;
            _logger = logger;
        }

        [HttpPost("addCandidate")]
        public async Task<IActionResult> AddCandidate(CandidateModel model)
        {
            await _service.AddCandidateAsync(model);
            return Ok(model);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _service.GetCandidateByIdAsync(id);
            return Ok(entity);
        }

        [HttpGet]
        [Route("GetAllCandidates")]
        public async Task<ActionResult<IEnumerable<CandidateModel>>> GetAllCandidatesAsync()
        {
            var candidates = await _service.GetAllCandidatesAsync();
            if (candidates == null)
            {
                return NotFound();
            }
            return Ok(candidates);
        }

        // [HttpGet]
        // public IActionResult ExceptionHandling(string input)
        // {
        //     throw new NullReferenceException();
        //     // try{
        //     //     throw new NullReferenceException();
        //     // }catch(Exception ex){
        //     //     _logger.LogError(ex.Message);
        //     //     return BadRequest(ex.Message);
        //     // }
        // }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteCandidateAsync(id);

            if (result == 0)
            {
                return NotFound();
            }

            return Ok(new { message = "Candidate deleted successfully." });
        }
    }
}
