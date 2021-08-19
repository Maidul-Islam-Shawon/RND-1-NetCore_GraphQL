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
                    Id = new Guid("8aeb058b-949c-4a87-9116-c217c8885a55"),
                    Name = "Liam Pit",
                    Age = 40,
                    Email = "liam.pit@gmail.com",
                    ContactNumber = "01907569879",
                    Address = "Dhaka"
                },
                new Customer
                {
                    Id = new Guid("d589b2bc-7254-4bbe-89e1-8b991bbc2920"),
                    Name = "Harry Style",
                    Age = 45,
                    Email = "harry44@yahoo.com",
                    ContactNumber = "01707769879",
                    Address = "Dhaka"
                },
                new Customer
                {
                    Id = new Guid("be0e0e97-3231-457a-bd97-819f979f78ab"),
                    Name = "Mark Henry",
                    Age = 47,
                    Email = "m.henry@gmail.com",
                    ContactNumber = "01707769779",
                    Address = "Borishal"
                },
                new Customer
                {
                    Id = new Guid("9d5d61b7-6d24-4bfa-b9e6-bce222980a55"),
                    Name = "Jonathon Rose",
                    Age = 56,
                    Email = "jonathon.rose@gmail.com",
                    ContactNumber = "01807769879",
                    Address = "Chittagong"
                },
                new Customer
                {
                    Id = new Guid("4b4e6c07-cecd-4314-a54c-a4469d43505a"),
                    Name = "Roberto Pereira",
                    Age = 37,
                    Email = "roberto.per@hotmail.com",
                    ContactNumber = "01707460809",
                    Address = "Cumilla"
                },
                new Customer
                {
                    Id = new Guid("5f8ebca5-3829-4049-9408-871086ae3299"),
                    Name = "Peter Parker",
                    Age = 60,
                    Email = "peter.parker@yahoo.com",
                    ContactNumber = "01707469070",
                    Address = "Sylhet"
                },
                new Customer
                {
                    Id = new Guid("4bcb565c-e344-4d07-83a2-4b7d5cab67be"),
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
