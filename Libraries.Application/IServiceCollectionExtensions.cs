using Libraries.Application.Commands;
using Libraries.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Libraries.Application
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterMediatRDependencies(this IServiceCollection services)
        {
            services.AddMediatR(option => option.RegisterServicesFromAssemblies(typeof(GetAllLibrariesQuery).Assembly));
            services.AddMediatR(option => option.RegisterServicesFromAssemblies(typeof(AddLibraryCommand).Assembly));
        }
    }
}