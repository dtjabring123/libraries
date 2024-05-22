using Libraries.Domain.Interfaces;
using Libraries.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Libraries.Infrastructure
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILibraryRepository, LibraryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}