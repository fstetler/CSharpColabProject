namespace Common.Result
{
    public class ResultGeneric<T> : Result
    {
        public T Value { get; }

        private ResultGeneric(T value) : base(true, null)
        {
            Value = value;
        }

        private ResultGeneric(string error) : base(false, error)
        {
            Value = default!;
        }

        public static ResultGeneric<T> Success(T value) => new ResultGeneric<T>(value);
        public static new ResultGeneric<T> Failure(string error) => new ResultGeneric<T>(error);
    }
}
