using Sovtech.ChuckSwapi.Contracts.Responses;
using System.Text.Json;

namespace Sovtech.ChuckSwapi.Api.Middlewares;

public class ErrorExceptionMiddleware
{
    private readonly RequestDelegate _request;
    private readonly ILogger<ErrorExceptionMiddleware> _logger;

    public ErrorExceptionMiddleware(RequestDelegate request, ILogger<ErrorExceptionMiddleware> logger)
    {
        _request = request;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (Exception ex)
        {

            ApiErrorResponse responseModel;
            var response = context.Response;
            response.ContentType = "application/json";
            switch (ex)
            {
                case ArgumentNullException exception:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    responseModel = new ApiErrorResponse(error: exception.Message);
                    break; 
                default:
                    // unhandled error
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    responseModel = new ApiErrorResponse(error: "Oops, Something went wrong.");
                    _logger.LogError(ex.Message, ex);
                    break;
            } 
            var result = JsonSerializer.Serialize(responseModel, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            await response.WriteAsync(result);
        }


    }
}
