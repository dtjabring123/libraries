using Libraries.Application.Services;
using Libraries.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Libraries.Application
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILibraryService, LibraryService>();
        }
    }
}