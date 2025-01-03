namespace YourProjectName.Application.APIResponse
{
    public class APIResponseHandler
    {
        public APIResponse<T> CreateSuccessResponse<T>(T payload, string? message = null, int statusCode = 200) where T : class
        {
            return APIResponse<T>.Success(payload, message, statusCode);
        }

        public APIResponse<T> CreateFailureResponse<T>(IEnumerable<string> errors, string? message = null, int statusCode = 400) where T : class
        {
            return APIResponse<T>.Failure(errors, message, statusCode);
        }

        public APIResponse<T> CreateUnauthorizedResponse<T>(string? message = null) where T : class
        {
            return APIResponse<T>.Failure(new[] { "Unauthorized access." }, message, 401);
        }

        public APIResponse<T> CreateForbiddenResponse<T>(string? message = null) where T : class
        {
            return APIResponse<T>.Failure(new[] { "Access is forbidden." }, message, 403);
        }
    }
}
