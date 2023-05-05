using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Onboarding.ApplicationCore.Contract.Model;
using Onboarding.ApplicationCore.Contract.Service;

namespace Onboarding.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmloyeeServiceAsync _employeeService;

        public EmployeeController(IEmloyeeServiceAsync employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetAllEmployeesAsync()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddEmployeeAsync([FromBody] EmployeeModel model)
        {
            var result = await _employeeService.AddEmployeeAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateEmployeeAsync(int id, EmployeeModel model)
        {
            model.Id = id;
            var result = await _employeeService.UpdateEmployeeAsync(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteEmployeeAsync(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
