namespace EmployeeTaskManagement.DTOs
{
    public class CreateTaskDto
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        public int EmployeeId { get; set; }

        public int StatusId { get; set; }
    }
}