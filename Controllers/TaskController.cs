using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Data.Models;
using MyFirstWebApi.Helpers;
using MyFirstWebApi.Models.DTO;
using MyFirstWebApi.Models.Response;
using MyFirstWebApi.Services;
using System.Net;

namespace MyFirstWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController
    {
        private readonly ITaskItemService _taskItemService;

        public TaskController(ITaskItemService taskService)
        {
            _taskItemService = taskService;
        }

        [HttpGet]
        [Route("GetAll")]
        public ApiResult<IEnumerable<TaskItem>> GetTasks()
        {
            IEnumerable<TaskItem> tasks = _taskItemService.GetTaskItems();
            return ApiHelper.Ok(tasks);
        }

        [HttpPut]
        [Route("AddTask")]
        public ApiResult<Object> CreateNewTask([FromForm] TaskItemDTO item)
        {
            if (string.IsNullOrWhiteSpace(item.Title))
                return ApiHelper.Fail("Title should be specified", HttpStatusCode.BadRequest);

            try
            {
                _taskItemService.AddTask(item);
                throw new Exception();
            }
            catch (Exception)
            {
                return ApiHelper.Fail("Something went wrong", HttpStatusCode.InternalServerError);
            }

            return ApiHelper.Ok();
        }

        [HttpDelete]
        [Route("DeleteTask")]
        public void DeleteTaskById(long id)
        {
            _taskItemService.DeleteTask(id);
        }

    }
}
