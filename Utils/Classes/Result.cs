namespace Utils.Classes
{
    public class Result<T>
    {
        public bool Success { get; init; }
        public T Value { get; set; }

        public Result(bool success)
        {
            this.Success = success;
            Value = default;
        }

        public Result(bool success, T value)
        {
            Success = success;
            Value = value;
        }

        public static bool operator true(Result<T> val) => val.Success;
        public static bool operator false(Result<T> val) => !val.Success;
        public static bool operator !(Result<T> val) => !val.Success;
        public static bool operator ==(Result<T> val, bool pBool) => val.Success == pBool;
        public static bool operator !=(Result<T> val, bool pBool) => val.Success != pBool;

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
