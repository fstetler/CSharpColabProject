using System.Net;

namespace Common.Result
{
    public class Result<T>
    {
        public T? Value { get; private set; } = default;
        public string? ErrorMessage { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }

        private Result(HttpStatusCode statusCode, string? error)
        {
            ErrorMessage = error;
            StatusCode = statusCode;
        }

        private Result(T value)
        {
            Value = value;
            StatusCode = HttpStatusCode.OK;
        }

        public static Result<T> Ok(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> BadRequest(string error)
        {
            return new Result<T>(HttpStatusCode.BadRequest, error);
        }

        public static Result<T> Unauthorized(string error)
        {
            return new Result<T>(HttpStatusCode.Unauthorized, error);
        }   

        public static Result<T> Forbidden(string error) 
        {
            return new Result<T>(HttpStatusCode.Forbidden, error);
        }

        public static Result<T> NotFound(string error)
        {
            return new Result<T>(HttpStatusCode.NotFound, error);
        }
    }
}