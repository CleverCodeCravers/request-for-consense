namespace RequestForConsense.BL.Common
{
    public class Result<T>
    {
        public T Value { get; private set; }
        public bool IsSuccess { get; private set; }
        public string Error { get; private set; }
        public bool IsFailure => !IsSuccess;

        protected Result(T value, bool isSuccess, string error)
        {
            Value = value;
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(value, true, null);
        }

        public static Result<T> Failure(string error)
        {
            return new Result<T>(default, false, error);
        }

        public bool IsSuccessWithValue(out T value)
        {
            value = IsSuccess ? Value : default;
            return IsSuccess;
        }
    }


}
