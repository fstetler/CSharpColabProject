using System.Net;

namespace Common.Result
{
    public class Result
    {
        private bool _success;
        private string? _errorMessage;
        private HttpStatusCode _statusCode;

        public Result(bool isSuccess, string? error, HttpStatusCode statusCode)
        {
            if (isSuccess && error is not null)
            {
                throw new InvalidOperationException("Success result cannot have an error");
            }

            if (!isSuccess && error is null)
            {
                throw new InvalidOperationException("Failure result must have an error");
            }

            if (statusCode == HttpStatusCode.NotFound)
            {
                throw new InvalidOperationException("Use NotFound factory method to create a NotFound result");
            }

            _success = isSuccess;
            _errorMessage = error;
            _statusCode = statusCode;
        }
        public bool IsSuccess() 
        {
            return _success;
        }
        public bool IsFailure()
        {
            return !_success;
        }
        public string? Error() 
        {
            return _errorMessage;
        }
        public HttpStatusCode StatusCode() 
        {
            return _statusCode;
        }

        public static Result Failure(string error, HttpStatusCode statusCode)
        {
            return new Result(false, error, statusCode);
        }

        public static Result Ok(HttpStatusCode statusCode)
        {
            return new Result(true, null, HttpStatusCode.OK);
        }

        public static Result BadRequest(string error)
        {
            return new Result(false, error, HttpStatusCode.BadRequest);
        }

        public static Result Unauthorized(string error)
        {
            return new Result(false, error, HttpStatusCode.Unauthorized);
        }

        public static Result Forbidden(string error)
        {
            return new Result(false, error, HttpStatusCode.Forbidden);
        }

        public static Result NotFound(string error)
        {
            return new Result(false, error, HttpStatusCode.NotFound);
        }
    }

    public class Result<T> : Result
    {
        private T _value;

        public T Value() 
        { 
            return _value; 
        }

        private Result(T value) : base(true, null, HttpStatusCode.OK)
        {
            _value = value;
        }

        private Result(T value, string error, HttpStatusCode statusCode) : base(false, error, HttpStatusCode.BadRequest)
        {
            _value = value;
        }
        
        public static Result<T> Failure(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Ok(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> BadRequest(T value, string error)
        {
            return new Result<T>(value, error, HttpStatusCode.BadRequest);
        }

        public static Result<T> Unauthorized(T value, string error)
        {
            return new Result<T>(value, error, HttpStatusCode.Unauthorized);
        }

        public static Result<T> Forbidden(T value, string error)
        {
            return new Result<T>(value, error, HttpStatusCode.Forbidden);
        }

        public static Result<T> NotFound(T value, string error)
        {
            return new Result<T>(value, error, HttpStatusCode.NotFound);
        }
    }
}
