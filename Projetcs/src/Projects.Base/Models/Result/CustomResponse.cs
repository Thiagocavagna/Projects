namespace Projects.Base.Models.Result
{
    public class CustomResponse
    {
        public Result Result { get; set; }
        public object? Data { get; set; }

        public CustomResponse() { }

        public CustomResponse(Result result, object data)
        {
            Result = result;
            Data = data;
        }
    }
}
