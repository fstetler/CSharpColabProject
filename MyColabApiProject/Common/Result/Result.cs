namespace Common.Result
{
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? Error { get; }

        protected Result(bool isSuccess, string? error)
        {
            if (isSuccess && error is not null)
            {
                throw new InvalidOperationException("Success result cannot have an error");
            }

            if (!isSuccess && error is null)
            {
                throw new InvalidOperationException("Failure result must have an error");
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new(true, null);
        public static Result Failure(string error) => new(false, error);
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        private Result(T value) : base(true, null)
        {
            Value = value;
        }

        private Result(string error) : base(false, error)
        {
            Value = default!;
        }

        public static Result<T> Success(T value) => new(value);
        public new static Result<T> Failure(string error) => new(error);
    }
}
