using EmployeeTaskManagement.Models;

namespace EmployeeTaskManagement.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem> AddAsync(TaskItem task);
        Task<IEnumerable<TaskItem>> GetByStatusAsync(int statusId);
        Task<IEnumerable<TaskItem>> GetByEmployeeAsync(int employeeId);
        Task UpdateStatusAsync(int taskId, int statusId);
    }
}