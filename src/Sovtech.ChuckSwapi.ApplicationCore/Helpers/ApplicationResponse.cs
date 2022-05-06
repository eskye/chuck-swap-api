using Newtonsoft.Json;
using System.Net;

namespace Sovtech.ChuckSwapi.ApplicationCore.Helpers;

public class ApplicationResponse<T>
{
	private HttpResponseMessage _httpResponseMessage;
	public HttpResponseMessage HttpResponseMessage { get { return _httpResponseMessage; } }
	 
	private bool _isError;
	public bool IsError { get { return _isError; } } 

	private string _errorMessage;
	public string ErrorMessage { get { return _errorMessage; } } 

	public HttpStatusCode StatusCode
	{
		get;
	}

	public ApplicationResponse()
	{

	}
	public ApplicationResponse(HttpResponseMessage httpResponseMessage)
	{
		if (httpResponseMessage is null)
			throw new ArgumentNullException(nameof(httpResponseMessage));

		if (!httpResponseMessage.IsSuccessStatusCode)
		{
			_isError = true; 
			_errorMessage = httpResponseMessage.ReasonPhrase;
		}
		_httpResponseMessage = httpResponseMessage;
		StatusCode = _httpResponseMessage?.StatusCode ?? HttpStatusCode.Unused;
	}

	public ApplicationResponse( string ErrorMessage, HttpStatusCode? statusCode = null)
	{
		StatusCode = statusCode ?? HttpStatusCode.Unused;
		_isError = true; 
		_errorMessage = ErrorMessage;
	}

	public T Data
	{
		get
		{
			if (_httpResponseMessage?.IsSuccessStatusCode ?? false)
			{
				var resultType = typeof(T); 
				var content = _httpResponseMessage?.Content.ReadAsStringAsync().GetAwaiter().GetResult();
				try
				{
					if (!string.IsNullOrEmpty(content))
					{
						if (resultType == typeof(string))
							return (T)Convert.ChangeType(content, typeof(T));

						var result = JsonConvert.DeserializeObject<T>(content);
						return result;
					}
				}
				catch (Exception ex)
				{
					throw new Exception($"Unable to convert result {content} into typeof {resultType}", ex);
				}
			}
			return default(T);
		}
	}

}
