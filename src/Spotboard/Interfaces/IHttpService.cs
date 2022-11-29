using System.Net.Http.Headers;

namespace Spotboard.Interfaces;

public interface IHttpService
{
    bool IsLoading { get; }
    Task<T> RequestAsync<T>(Func<Task<HttpResponseMessage>> requestAction);
    Task<HttpResponseMessage> GetAsync(string request, string query = "");
    Task<HttpResponseMessage> PostAsync(string request, string jsonString);
    Task<HttpResponseMessage> PostAsync(string request, FormUrlEncodedContent formUrl);
    void SetHeader(string schema, string authorization);
}