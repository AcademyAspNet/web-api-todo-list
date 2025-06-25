using MyFirstWebApi.Data.Models;
using MyFirstWebApi.Models.DTO;

namespace MyFirstWebApi.Services
{
    public interface ITaskItemService
    {
        void AddTask(TaskItemDTO task);
        void DeleteTask(long id);
        List<TaskItem> GetTaskItems();
        TaskItem? GetTaskItemById(long id);
        void EditTask(long id, TaskItemDTO taskDto);
    }
}
