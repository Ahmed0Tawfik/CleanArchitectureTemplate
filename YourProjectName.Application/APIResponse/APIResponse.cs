namespace YourProjectName.Application.APIResponse
{
    public class APIResponse<T> where T : class
    {
        public bool IsError { get; set; }
        public ICollection<string> Errors { get; set; } = new List<string>();
        public T? Payload { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }

        public static APIResponse<T> Success(T payload, string? message = null, int statusCode = 200)
        {
            return new APIResponse<T>
            {
                IsError = false,
                Payload = payload,
                Message = message,
                StatusCode = statusCode
            };
        }

        public static APIResponse<T> Failure(IEnumerable<string> errors, string? message = null, int statusCode = 400)
        {
            return new APIResponse<T>
            {
                IsError = true,
                Errors = new List<string>(errors),
                Message = message,
                StatusCode = statusCode
            };
        }
    }
}
