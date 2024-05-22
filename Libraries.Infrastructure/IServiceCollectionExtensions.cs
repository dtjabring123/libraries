using Libraries.Domain.Interfaces;
using Libraries.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Libraries.Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}