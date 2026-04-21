namespace Common.Result
{ 
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string Error { get; }

        public Result(bool isSuccess, string error)
        {
            if (isSuccess && error != null)
            {
                throw new InvalidOperationException("Success result cannot have an error");
            }

            if (!isSuccess && error == null)
            {
                throw new InvalidOperationException("Failure result must have an error");
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new Result(true, null);
        public static Result Failure(string error) => new Result(false, error);
    }

}
