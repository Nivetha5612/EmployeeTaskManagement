namespace EmployeeTaskManagement.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public int EmployeeId { get; set; }

        public int StatusId { get; set; }
    }
}