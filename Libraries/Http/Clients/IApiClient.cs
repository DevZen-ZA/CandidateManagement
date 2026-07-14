namespace Http.Clients
{
    public interface IApiClient<out ResponseObject, in RequestObject> where ResponseObject : class where RequestObject : class
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T, U>(string url, U request);
    }
}