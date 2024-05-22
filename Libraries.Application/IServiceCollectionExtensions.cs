﻿using Libraries.Application.Commands.Library;
using Libraries.Application.Queries.Library;
using Microsoft.Extensions.DependencyInjection;

namespace Libraries.Application
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterMediatRDependencies(this IServiceCollection services)
        {
            services.AddMediatR(option => option.RegisterServicesFromAssemblies(typeof(GetAllLibrariesQuery).Assembly));
            services.AddMediatR(option => option.RegisterServicesFromAssemblies(typeof(GetLibraryByIdQuery).Assembly));
            services.AddMediatR(option => option.RegisterServicesFromAssemblies(typeof(AddLibraryCommand).Assembly));
            services.AddMediatR(option => option.RegisterServicesFromAssemblies(typeof(DeleteLibraryCommand).Assembly));
        }
    }
}