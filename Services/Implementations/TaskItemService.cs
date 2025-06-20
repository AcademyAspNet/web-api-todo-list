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
        public void AddTask(TaskItemDTO task)
        {
            throw new NotImplementedException();
        }

        public List<TaskItem> GetTaskItems()
        {
            return _database.TaskItems.ToList();
        }
    }
}
