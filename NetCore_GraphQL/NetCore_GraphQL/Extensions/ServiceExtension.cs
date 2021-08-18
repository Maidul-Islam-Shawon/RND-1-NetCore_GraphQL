using GraphQL.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetCore_GraphQL.Data;
using NetCore_GraphQL.GraphQL;
using NetCore_GraphQL.Repository;
using NetCore_GraphQL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_GraphQL.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }

        public static void ConfigureInMemoryDatabase(this IServiceCollection services)
        {
            services.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<NetCoreGraphQL_Context>(option =>
                {
                    option.UseInMemoryDatabase("GraphQlApiDB");
                });
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }

        public static void ConfigureGraphQl(this IServiceCollection services)
        {
            services.AddScoped<AppSchema>();
            services.AddGraphQL()
                .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped)
                .AddSystemTextJson()
                .AddDataLoader();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {

        }
    }
}
