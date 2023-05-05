using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Onboarding.ApplicationCore.Contract.Model;
using Onboarding.ApplicationCore.Contract.Service;
using Onboarding.ApplicationCore.Model.Post;

namespace Onboarding.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeCategoryController : ControllerBase
    {
        private readonly IEmloyeeCategoryServiceAsync _employeeCategoryService;

        public EmployeeCategoryController(IEmloyeeCategoryServiceAsync employeeCategoryService)
        {
            _employeeCategoryService = employeeCategoryService;
        }

        [HttpGet]
        [Route("GetAllEmployeeCategories")]
        public async Task<
            ActionResult<IEnumerable<EmployeeCategoryModel>>
        > GetAllEmployeeCategoriesAsync()
        {
            var employeeCategories = await _employeeCategoryService.GetAllEmployeeCategorysAsync();
            if (employeeCategories == null)
            {
                return NotFound();
            }
            return Ok(employeeCategories);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<ActionResult<EmployeeCategoryModel>> GetEmployeeCategoryByIdAsync(int id)
        {
            var employeeCategory = await _employeeCategoryService.GetEmployeeCategoryByIdAsync(id);
            if (employeeCategory == null)
            {
                return NotFound();
            }
            return Ok(employeeCategory);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddEmployeeCategoryAsync(
            [FromBody] EmployeeCategoryPostModel model
        )
        {
            var result = await _employeeCategoryService.AddEmployeeCategoryAsync(model);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<int>> UpdateEmployeeCategoryAsync(
            int id,
            EmployeeCategoryModel model
        )
        {
            model.Id = id;
            var result = await _employeeCategoryService.UpdateEmployeeCategoryAsync(model);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteEmployeeCategoryAsync(int id)
        {
            var result = await _employeeCategoryService.DeleteEmployeeCategoryAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
