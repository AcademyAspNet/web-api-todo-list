namespace MyFirstWebApi.Models.DTO
{
    public class TaskItemDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
