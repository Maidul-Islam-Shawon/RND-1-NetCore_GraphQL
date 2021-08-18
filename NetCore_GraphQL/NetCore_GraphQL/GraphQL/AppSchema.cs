using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using NetCore_GraphQL.GraphQL.Queries;
using System;

namespace NetCore_GraphQL.GraphQL
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider services) : base(services)
        {
            Query = services.GetRequiredService<QueryObject>();
        }
    }
}
