namespace Sovtech.ChuckSwapi.Contracts.Responses;

public class ApiResponseBase
{
    public bool Succeeded { get; }
    public string Message { get; }

    protected ApiResponseBase(bool succeeded, string message)
    {
        Succeeded = succeeded;
        Message = message;
    }
}