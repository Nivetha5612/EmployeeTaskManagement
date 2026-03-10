using EmployeeTaskManagement.DTOs;
using EmployeeTaskManagement.Models;
using EmployeeTaskManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _repo;

        public TasksController(ITaskRepository repo)
        {
            _repo = repo;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _repo.GetAllAsync();
            return Ok(tasks);
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                EmployeeId = dto.EmployeeId,
                StatusId = dto.StatusId,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _repo.AddAsync(task);

            return Ok(result);
        }

        // GET: api/tasks/status/1
        [HttpGet("status/{statusId}")]
        public async Task<IActionResult> GetByStatus(int statusId)
        {
            var tasks = await _repo.GetByStatusAsync(statusId);
            return Ok(tasks);
        }

        // PUT: api/tasks/update-status
        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateStatus(UpdateTaskStatusDto dto)
        {
            try
            {
                await _repo.UpdateStatusAsync(dto.TaskId, dto.StatusId);

                return Ok("Task status updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/tasks/employee/3
        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetTasksByEmployee(int employeeId)
        {
            var tasks = await _repo.GetByEmployeeAsync(employeeId);
            return Ok(tasks);
        }
    }
}