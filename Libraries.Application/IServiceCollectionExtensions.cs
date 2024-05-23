using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Libraries.Application
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterMediatRDependencies(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}