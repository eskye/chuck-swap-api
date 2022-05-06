using System.Net;

namespace Sovtech.ChuckSwapi.ApplicationCore.Helpers;

public class ApplicationResponse : ApplicationResponse<bool>
{
	public ApplicationResponse()
	{

	}
	public ApplicationResponse(HttpResponseMessage httpResponseMessage) : base(httpResponseMessage)
	{
	}

	public ApplicationResponse(string ErrorMessage, HttpStatusCode? statusCode = null) : base(ErrorMessage, statusCode)
	{
	}
}
