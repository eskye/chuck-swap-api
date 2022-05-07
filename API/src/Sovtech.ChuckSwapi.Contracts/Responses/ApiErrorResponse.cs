namespace Sovtech.ChuckSwapi.Contracts.Responses;
public class ApiErrorResponse : ApiResponseBase
{
    public ApiErrorResponse(string message) : base(false, "One or more validation error occurred")
    {
    }

    public ApiErrorResponse(string error, string message = "One or more validation error occurred") : base(false, message)
    {
        Error = error;
    }
    public string Error { get; private set; }
}
