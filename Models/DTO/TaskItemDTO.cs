using MyFirstWebApi.Data.Models;

namespace MyFirstWebApi.Models.DTO
{
    public class TaskItemDTO : IToDataTransferObject<TaskItem>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsDone { get; set; }
        public DateTime? CreatedAt { get; set; }

        public TaskItem ToEntity()
        {
            TaskItem taskItem = new TaskItem()
            {
                Title = Title!,
                Description = Description
            };

            if (IsDone != null)
                taskItem.IsDone = (bool) IsDone;

            if (CreatedAt != null)
                taskItem.CreatedAt = (DateTime) CreatedAt;

            return taskItem;
        }
    }
}
