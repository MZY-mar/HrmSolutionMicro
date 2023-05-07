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
    public class EmployeeRoleController : ControllerBase
    {
        private readonly IEmloyeeRoleServiceAsync _employeeRoleService;

        public EmployeeRoleController(IEmloyeeRoleServiceAsync employeeRoleService)
        {
            _employeeRoleService = employeeRoleService;
        }

        [HttpGet]
        [Route("GetAllEmployeeRoles")]
        public async Task<ActionResult<IEnumerable<EmployeeRoleModel>>> GetAllEmployeeRolesAsync()
        {
            var employeeRoles = await _employeeRoleService.GetAllEmployeeRolesAsync();
            if (employeeRoles == null)
            {
                return NotFound();
            }
            return Ok(employeeRoles);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<EmployeeRoleModel>> GetEmployeeRoleByIdAsync(int id)
        {
            var employeeRole = await _employeeRoleService.GetEmployeeRoleByIdAsync(id);
            if (employeeRole == null)
            {
                return NotFound();
            }
            return Ok(employeeRole);
        }

        [HttpPost]
        [Route("addEmpRole")]
        public async Task<ActionResult<int>> AddEmployeeRoleAsync(
            [FromBody] EmployeeRoleModel model
        )
        {
            var result = await _employeeRoleService.AddEmployeeRoleAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateEmployeeRoleAsync(
            int id,
            EmployeeRoleModel model
        )
        {
            model.Id = id;
            var result = await _employeeRoleService.UpdateEmployeeRoleAsync(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteEmployeeRoleAsync(int id)
        {
            var result = await _employeeRoleService.DeleteEmployeeRoleAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
