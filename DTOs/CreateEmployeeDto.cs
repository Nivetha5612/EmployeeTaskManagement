namespace EmployeeTaskManagement.DTOs
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int DepartmentId { get; set; }
    }
}