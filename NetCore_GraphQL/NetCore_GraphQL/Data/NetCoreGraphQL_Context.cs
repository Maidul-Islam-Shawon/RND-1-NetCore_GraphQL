using Microsoft.EntityFrameworkCore;
using NetCore_GraphQL.Data.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore_GraphQL.Data.Entities;

namespace NetCore_GraphQL.Data
{
    public class NetCoreGraphQL_Context : DbContext
    {
        public NetCoreGraphQL_Context(DbContextOptions<NetCoreGraphQL_Context> options) : base(options)
        {
        }

        public DbSet<NetCore_GraphQL.Data.Entities.Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CustomerSeedData.Data(modelBuilder);
            
        }

        
    }
}
