using System;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using TodoList.Framework;
using TodoList.Services;

namespace TodoList.Project.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(
        this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddScoped<IJsonSerializable, JsonSerializableHelper>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ITodoItemService, TodoItemService>();

            return services;
        }


    }
}
