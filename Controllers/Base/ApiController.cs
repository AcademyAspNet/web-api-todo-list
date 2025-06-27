using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Helpers;
using MyFirstWebApi.Models.Response;
using System.Net;

namespace MyFirstWebApi.Controllers.Base
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IActionResult ApiOk()
        {
            return Ok(ApiHelper.Ok<object>(null));
        }

        protected IActionResult ApiOk<T>(T result)
        {
            return Ok(ApiHelper.Ok(result));
        }

        protected IActionResult ApiFail(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return StatusCode((int) statusCode, ApiHelper.Fail(errorMessage, statusCode));
        }

        protected IActionResult ApiNotFound(string errorMessage = "Resource not found")
        {
            return NotFound(ApiHelper.Fail(errorMessage, HttpStatusCode.NotFound));
        }
    }
}
