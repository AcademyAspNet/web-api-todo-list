using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Controllers.Base;
using MyFirstWebApi.Data.Models;
using MyFirstWebApi.Exceptions;
using MyFirstWebApi.Helpers;
using MyFirstWebApi.Models.DTO;
using MyFirstWebApi.Models.Response;
using MyFirstWebApi.Services;
using System.Net;

namespace MyFirstWebApi.Controllers
{
    [ApiController]
    [Route("v1/tasks")]
    public class TaskController : ApiController
    {
        private readonly ITaskItemService _taskItemService;

        public TaskController(ITaskItemService taskService)
        {
            _taskItemService = taskService;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            return ApiOk(_taskItemService.GetTaskItems());
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult GetTask(long id)
        {
            TaskItem? task = _taskItemService.GetTaskItemById(id);

            if (task == null)
                return ApiNotFound();

            return ApiOk(task);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IActionResult DeleteTask([FromRoute] long id)
        {
            _taskItemService.DeleteTask(id);
            return ApiOk();
        }

        [HttpPost]
        public IActionResult CreateTask([FromForm] TaskItemDTO item)
        {
            if (string.IsNullOrWhiteSpace(item.Title))
                return ApiFail("Title should be specified", HttpStatusCode.BadRequest);

            _taskItemService.AddTask(item);

            return ApiOk();
        }

        [HttpPatch]
        [Route("{id:long}")]
        public IActionResult EditTask(long id, [FromForm] TaskItemDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                return BadRequest("Title should be specified");

            try
            {
                _taskItemService.EditTask(id, dto);
            }
            catch (TaskNotFoundException)
            {
                return ApiNotFound("Task not found");
            }

            return ApiOk();
        }

        [HttpGet]
        [Route("exception")]
        public void ThrowException()
        {
            throw new Exception();
        }
    }
}
