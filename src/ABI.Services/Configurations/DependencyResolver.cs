using ABI.Adapter.NamedPipe;
using ABI.Adapter.NamedPipe.Queries.GetAirpodsBatteryStatus;
using ABI.Core.Entities;
using ABI.Core.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace ABI.Services.Configurations
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterTypes(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IQueryHandler<GetAirpodsBatteryStatusQuery, BatteryIndicator>, GetAirpodsBatteryStatusQueryHandler>();
            serviceCollection.AddScoped<NamedPipeContext>();

            return serviceCollection;
        }
    }
}
