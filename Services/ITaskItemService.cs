using MyFirstWebApi.Data.Models;
using MyFirstWebApi.Models.DTO;

namespace MyFirstWebApi.Services
{
    public interface ITaskItemService
    {
        void AddTask(TaskItemDTO task);
        List<TaskItem> GetTaskItems();
    }
}
