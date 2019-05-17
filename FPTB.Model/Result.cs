namespace FPTB.Model
{
    public class Result
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Result<T> : Result
    {
        public T ReturnObject { get; set; }
    }
}
