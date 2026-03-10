using EmployeeTaskManagement.DTOs;
using EmployeeTaskManagement.Models;
using EmployeeTaskManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;

        public EmployeesController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _repo.GetAllAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                DepartmentId = dto.DepartmentId
            };

            var result = await _repo.AddAsync(employee);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}