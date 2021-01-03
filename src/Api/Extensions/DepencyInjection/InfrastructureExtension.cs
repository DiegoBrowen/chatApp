using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Api.Extensions.DepencyInjection
{
    public static class InfrastructureExtension
    {

        public static void RegisterInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton(x => new List<Sala> { new Sala("Sala1"), new Sala("Sala2"), new Sala("Sala3") });
            services.AddScoped<ISalaRepository, SalaRepository>();
        }
    }
}
