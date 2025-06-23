using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Models.Response;
using System.Net;

namespace MyFirstWebApi.Helpers
{
    public class ApiHelper
    {
        public static ApiResult<T> Ok<T>(T result)
        {
            return new ApiResult<T>()
            {
                Success = true,
                Result = result
            };
        }

        public static ApiResult<Object> Ok()
        {
            return Ok<Object>(new object());
        }

        public static ApiResult<Object> Fail(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ApiResult<Object>()
            {
                Success = false,
                Result = default(Object),
                Error = new ErrorMessage()
                {
                    Code = (int) statusCode,
                    Message = errorMessage
                }
            };
        }
    }
}
