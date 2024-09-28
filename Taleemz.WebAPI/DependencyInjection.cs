using Taleemz.Application;
using Taleemz.Infrastructure;

namespace Taleemz.WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddApplicationDI()
                    .AddInfrastructureDI();

            return services;
        }
    }
}
