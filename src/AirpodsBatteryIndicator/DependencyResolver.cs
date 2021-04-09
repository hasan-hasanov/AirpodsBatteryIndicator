using Microsoft.Extensions.DependencyInjection;

namespace AirpodsBatteryIndicator
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterTypes(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<MainForm>();

            return serviceCollection;
        }
    }
}
