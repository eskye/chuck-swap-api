namespace Sovtech.ChuckSwapi.Contracts.Responses;
public class ApiErrorResponse : ApiResponseBase
{
    public ApiErrorResponse(string message) : base(false, message)
    {
    }

    public ApiErrorResponse(string error, string message = "") : base(false, message)
    {
        Error = error;
    }
    public string Error { get; private set; }
}
