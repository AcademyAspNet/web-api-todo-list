using MyFirstWebApi.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace MyFirstWebApi.Data.Models
{
    public class TaskItem
    {
        [Key]
        public long ID { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
