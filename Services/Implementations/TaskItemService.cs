using Microsoft.EntityFrameworkCore;
using MyFirstWebApi.Data;
using MyFirstWebApi.Data.Models;
using MyFirstWebApi.Exceptions;
using MyFirstWebApi.Helpers;
using MyFirstWebApi.Models.DTO;
using System.Net;
using System.Threading.Tasks;

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

        public void EditTask(long id, TaskItemDTO taskDto)
        {
            TaskItem? task = GetTaskItemById(id);

            if (task == null)
                throw new TaskNotFoundException(id);

            task.Title = taskDto.Title ?? task.Title;
            task.Description = taskDto.Description ?? task.Description;
            task.IsDone = taskDto.IsDone ?? task.IsDone;
            task.CreatedAt = taskDto.CreatedAt ?? task.CreatedAt;

            _database.SaveChanges();
        }

        public TaskItem? GetTaskItemById(long id)
        {
            return _database.TaskItems.Where(task => task.ID == id).FirstOrDefault();
        }

        public List<TaskItem> GetTaskItems()
        {
            return _database.TaskItems.ToList();
        }
    }
}
