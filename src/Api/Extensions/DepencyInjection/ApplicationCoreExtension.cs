using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions.DepencyInjection
{
    public static class ApplicationCoreExtension
    {
        public static void RegisterApplicationCore(this IServiceCollection services)
        {
            services.AddScoped<ISalaService, SalaService>();
        }
    }
}
