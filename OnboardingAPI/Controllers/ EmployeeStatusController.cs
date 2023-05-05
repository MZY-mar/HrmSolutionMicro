using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Onboarding.ApplicationCore.Contract.Model;
using Onboarding.ApplicationCore.Contract.Service;

namespace Onboarding.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeStatusController : ControllerBase
    {
        private readonly IEmloyeeStatusServiceAsync _employeeStatusService;

        public EmployeeStatusController(IEmloyeeStatusServiceAsync employeeStatusService)
        {
            _employeeStatusService = employeeStatusService;
        }

        [HttpGet]
        [Route("GetAllEmployeeStatuses")]
        public async Task<
            ActionResult<IEnumerable<EmployeeStatusModel>>
        > GetAllEmployeeStatusesAsync()
        {
            var employeeStatuses = await _employeeStatusService.GetAllEmployeeStatusesAsync();
            if (employeeStatuses == null)
            {
                return NotFound();
            }
            return Ok(employeeStatuses);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<EmployeeStatusModel>> GetEmployeeStatusByIdAsync(int id)
        {
            var employeeStatus = await _employeeStatusService.GetEmployeeStatusByIdAsync(id);
            if (employeeStatus == null)
            {
                return NotFound();
            }
            return Ok(employeeStatus);
        }

        [HttpPost]
        [Route("addEmpStatus")]
        public async Task<ActionResult<int>> AddEmployeeStatusAsync(
            [FromBody] EmployeeStatusModel model
        )
        {
            var result = await _employeeStatusService.AddEmployeeStatusAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateEmployeeStatusAsync(
            int id,
            EmployeeStatusModel model
        )
        {
            model.Id = id;
            var result = await _employeeStatusService.UpdateEmployeeStatusAsync(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteEmployeeStatusAsync(int id)
        {
            var result = await _employeeStatusService.DeleteEmployeeStatusAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
