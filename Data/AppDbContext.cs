using Microsoft.EntityFrameworkCore;
using EmployeeTaskManagement.Models;
using TaskStatusModel = EmployeeTaskManagement.Models.TaskStatus;

namespace EmployeeTaskManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<TaskItem> Tasks { get; set; }

        public DbSet<TaskStatusModel> TaskStatuses { get; set; }

        public DbSet<TaskHistory> TaskHistories { get; set; }
    }
}