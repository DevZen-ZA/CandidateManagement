using System.Net.Http.Json;

namespace Http.Clients
{
    public class ApiClient<ResponseObject, RequestObject>(HttpClient httpClient) : IApiClient<ResponseObject, RequestObject> where ResponseObject : class where RequestObject : class
    {
        public async Task<T> GetAsync<T>(string url)
        {
            var response = await httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<T>();

            return result is null ? throw new InvalidOperationException("Response content was null.") : result;
        }

        public async Task<T> PostAsync<T, U>(string url, U request)
        {
            var response = await httpClient.PostAsJsonAsync(url, request);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<T>();

            return result is null ? throw new InvalidOperationException("Response content was null.") : result;
        }
    }
}
