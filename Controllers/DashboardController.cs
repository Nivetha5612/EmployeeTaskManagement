using EmployeeTaskManagement.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStats()
        {
            var totalEmployees = _context.Employees.Count();
            var totalTasks = _context.Tasks.Count();
            var pendingTasks = _context.Tasks.Count(t => t.StatusId == 1);
            var inProgressTasks = _context.Tasks.Count(t => t.StatusId == 2);
            var completedTasks = _context.Tasks.Count(t => t.StatusId == 3);

            return Ok(new
            {
                totalEmployees,
                totalTasks,
                pendingTasks,
                inProgressTasks,
                completedTasks
            });
        }
    }
}