using Microsoft.EntityFrameworkCore;
using MyFirstWebApi.Data;
using MyFirstWebApi.Data.Models;
using MyFirstWebApi.Models.DTO;

namespace MyFirstWebApi.Services.Implementations
{
    public class TaskItemService : ITaskItemService
    {
        ApplicationDbContext _database;

        public TaskItemService(ApplicationDbContext database)
        {
            _database = database;
        }

        public void AddTask(TaskItemDTO taskItemDto)
        {
            TaskItem taskItem = taskItemDto.ToEntity();

            _database.TaskItems.Add(taskItem);
            _database.SaveChanges();
        }

        public void DeleteTask(long id)
        {
            _database.TaskItems.Where(task => task.ID == id).ExecuteDelete();
        }


        public List<TaskItem> GetTaskItems()
        {
            return _database.TaskItems.ToList();
        }
    }
}
