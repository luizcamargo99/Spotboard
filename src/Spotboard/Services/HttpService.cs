using Newtonsoft.Json;
using Spotboard.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Spotboard.Services;

internal class HttpService : IHttpService
{
    private const string _mediaType = "application/json";
    private HttpClient _httpClient { get; set; } = new HttpClient();
    public bool IsLoading { get; private set; }

    public async Task<T> RequestAsync<T>(Func<Task<HttpResponseMessage>> requestAction)
    {
        var result = new HttpResponseMessage();

        try
        {
            IsLoading = true;

            result = await requestAction();

            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                //
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            IsLoading = false;
        }

        return JsonConvert.DeserializeObject<T>(await result.Content.ReadAsStringAsync());
    }

    public async Task<HttpResponseMessage> GetAsync(string request, string query = "")
    {
        return await _httpClient.GetAsync(string.Concat(request, query));
    }
    public async Task<HttpResponseMessage> PostAsync(string request, string jsonString)
    {
        return await _httpClient.PostAsync(request, ConvertStringToStringContent(jsonString));
    }

    public async Task<HttpResponseMessage> PostAsync(string request, FormUrlEncodedContent formUrl)
    {
        return await _httpClient.PostAsync(request, formUrl);
    }

    private StringContent ConvertStringToStringContent(string jsonString)
    {
        return new StringContent(jsonString is null ? string.Empty : jsonString, System.Text.Encoding.Default, _mediaType);
    }

    public void SetHeader(string schema, string? authorization)
    {
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(schema, authorization);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

}
