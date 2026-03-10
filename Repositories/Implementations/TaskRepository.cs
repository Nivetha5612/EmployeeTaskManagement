using EmployeeTaskManagement.Data;
using EmployeeTaskManagement.Models;
using EmployeeTaskManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace EmployeeTaskManagement.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _context.Tasks
                .Include(t => t.Employee)
                .Include(t => t.Status)
                .ToListAsync();
        }

        public async Task<TaskItem> AddAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task UpdateStatusAsync(int taskId, int statusId)
        {
            var task = await _context.Tasks.FindAsync(taskId);

            if (task == null)
                throw new Exception("Task not found");

            var oldStatus = task.StatusId;

            // update task status
            task.StatusId = statusId;

            // create history record
            var history = new TaskHistory
            {
                TaskId = taskId,
                OldStatusId = oldStatus,
                NewStatusId = statusId,
                UpdatedBy = "System",
                UpdatedAt = DateTime.UtcNow
            };

            _context.TaskHistories.Add(history);

            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<TaskItem>> GetByStatusAsync(int statusId)
        {
            return await _context.Tasks
                .Where(t => t.StatusId == statusId)
                .ToListAsync();
        }
        public async Task<IEnumerable<TaskItem>> GetByEmployeeAsync(int employeeId)
        {
            return await _context.Tasks
                .Where(t => t.EmployeeId == employeeId)
                .ToListAsync();
        }
    }
}