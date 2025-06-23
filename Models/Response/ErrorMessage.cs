namespace MyFirstWebApi.Models.Response
{
    public class ErrorMessage
    {
        public int Code { get; set; }
        public required string Message { get; set; }
    }
}
