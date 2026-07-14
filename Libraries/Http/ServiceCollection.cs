using Http.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace Http
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddApiClient<ResponseObject, RequestObject>(this IServiceCollection services) where ResponseObject : class where RequestObject : class
        {
            services.AddScoped<IApiClient<ResponseObject, RequestObject>, ApiClient<ResponseObject, RequestObject>>();

            return services;
        }
    }
}
