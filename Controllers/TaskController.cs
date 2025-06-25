using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
    public class TaskController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;

        public TaskController(ITaskItemService taskService)
        {
            _taskItemService = taskService;
        }

        [HttpGet]
        public IEnumerable<TaskItem> GetTasks()
        {
            return _taskItemService.GetTaskItems();
        }

        [HttpGet]
        [Route("{id:long}")]
        public IActionResult GetTask(long id)
        {
            TaskItem? task = _taskItemService.GetTaskItemById(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public IActionResult DeleteTask([FromRoute] long id)
        {
            _taskItemService.DeleteTask(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateTask([FromForm] TaskItemDTO item)
        {
            if (string.IsNullOrWhiteSpace(item.Title))
                return BadRequest("Title should be specified");

            _taskItemService.AddTask(item);

            return Ok();
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
                return NotFound("Task not found");
            }

            return Ok();
        }
    }
}
