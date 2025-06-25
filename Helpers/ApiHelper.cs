using Microsoft.AspNetCore.Mvc;
using MyFirstWebApi.Models.Response;
using System.Net;

namespace MyFirstWebApi.Helpers
{
    public class ApiHelper
    {
        public static ApiResult<T> Ok<T>(T? result = default)
        {
            return new ApiResult<T>()
            {
                Success = true,
                Result = result
            };
        }

        public static ApiResult<T> Fail<T>(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        {
            return new ApiResult<T>()
            {
                Success = false,
                Result = default,
                Error = new ErrorMessage()
                {
                    Code = (int) statusCode,
                    Message = errorMessage
                }
            };
        }
    }
}
