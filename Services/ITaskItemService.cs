using MyFirstWebApi.Data.Models;
using MyFirstWebApi.Models.DTO;

namespace MyFirstWebApi.Services
{
    public interface ITaskItemService
    {
        void AddTask(TaskItemDTO task);
        void DeleteTask(long id);
        List<TaskItem> GetTaskItems();
    }
}
