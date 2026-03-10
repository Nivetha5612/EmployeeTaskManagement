public class TaskHistory
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public int OldStatusId { get; set; }

    public int NewStatusId { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }
}