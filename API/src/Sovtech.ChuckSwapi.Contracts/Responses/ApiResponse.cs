namespace Sovtech.ChuckSwapi.Contracts.Responses;

public class ApiResponse<T> : ApiResponseBase
{
    public ApiResponse(bool succeeded) : base(succeeded, string.Empty)
    {
    }
    public ApiResponse(T data, string message = "", bool succeeded = true) : base(succeeded, message)
    {
        Data = data;
    }
    public ApiResponse(string message) : base(true, message)
    {
    }
    public T Data { get; }
}