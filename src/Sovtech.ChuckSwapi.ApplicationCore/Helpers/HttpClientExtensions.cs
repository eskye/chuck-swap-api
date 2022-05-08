using Sovtech.ChuckSwapi.ApplicationCore.Exceptions;

namespace Sovtech.ChuckSwapi.ApplicationCore.Helpers;
public static class HttpClientExtensions
{

	private static async Task<ApplicationResponse<T>> CreateApplicationResponse<T>(HttpResponseMessage response)
	{
		if (!response.IsSuccessStatusCode)
		{
			if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
				throw new ApiException("Service is found but endpoint may be wrong", response.StatusCode);

			var result = await response.Content.ReadAsStringAsync();
			return new ApplicationResponse<T>(string.IsNullOrEmpty(result) ? response.ReasonPhrase : result);
		}
		return new ApplicationResponse<T>(response);
	}

	private static async Task<ApplicationResponse> CreateApplicationResponse(HttpResponseMessage response)
	{
		if (response.IsSuccessStatusCode != true)
		{
			if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
				return new ApplicationResponse("Service is found but endpoint may be wrong", response.StatusCode);

			var result = await response.Content.ReadAsStringAsync();
			return new ApplicationResponse(string.IsNullOrEmpty(result) ? response.ReasonPhrase : result);
		}
		return new ApplicationResponse(response);
	}

	public static async Task<ApplicationResponse<T>> HttpGetAsync<T>(this HttpClient client, string requestUri, CancellationToken cancellationToken = default(CancellationToken))
	{
		try
		{
			  
			var response = await client.GetAsync(requestUri, cancellationToken);

			return await CreateApplicationResponse<T>(response);
		}
		catch (HttpRequestException ex)
		{
			return new ApplicationResponse<T>($"Check if service is running or endpoint is correct. {ex.ToString()}");
		}
	} 

}
