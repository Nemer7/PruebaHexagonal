namespace Domain.Common.Wrappers
{
    public class Response<T>
    {
        public string Message { get; set; }

        public bool Success { get; set; }

        public T Data { get; set; }

        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }

        public Response(T data, string message = "")
        {
            Data = data;
            Message = message;
            Success = true;
            
        }

        public Response() { 
        
        }

        public Response(int statusCode, string message)
        {
            Message = message;
            Success = false;
            StatusCode = statusCode;
        }

       





    }
}
