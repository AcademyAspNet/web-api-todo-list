using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MyFirstWebApi.Models.Response
{
    public class ApiResult<T>
    {
        public required bool Success { get; set; }
        public T? Result { get; set; }
        public ErrorMessage? Error { get; set; }
    }
}
