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
            serviceCollection.AddSingleton<IQueryHandler<GetAirpodsBatteryStatusQuery, BatteryIndicator>, GetAirpodsBatteryStatusQueryHandler>();

            return serviceCollection;
        }
    }
}
