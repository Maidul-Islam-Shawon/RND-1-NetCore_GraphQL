using Microsoft.EntityFrameworkCore;
using NetCore_GraphQL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_GraphQL.Data.SeedData
{
    public static class CustomerSeedData
    {
        public static void Data(this ModelBuilder builder)
        {
            builder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Liam Pit",
                    Age = 40,
                    Email = "liam.pit@gmail.com",
                    ContactNumber = "01907569879",
                    Address = "Dhaka"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Harry Style",
                    Age = 45,
                    Email = "harry44@yahoo.com",
                    ContactNumber = "01707769879",
                    Address = "Dhaka"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Mark Henry",
                    Age = 47,
                    Email = "m.henry@gmail.com",
                    ContactNumber = "01707769779",
                    Address = "Borishal"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Jonathon Rose",
                    Age = 56,
                    Email = "jonathon.rose@gmail.com",
                    ContactNumber = "01807769879",
                    Address = "Chittagong"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Roberto Pereira",
                    Age = 37,
                    Email = "roberto.per@hotmail.com",
                    ContactNumber = "01707460809",
                    Address = "Cumilla"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Peter Parker",
                    Age = 60,
                    Email = "peter.parker@yahoo.com",
                    ContactNumber = "01707469070",
                    Address = "Sylhet"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Lorren Gates",
                    Age = 49,
                    Email = "lorren.gates@gmail.com",
                    ContactNumber = "01707469474",
                    Address = "Khulna"
                }
                );
        }
    }
}
