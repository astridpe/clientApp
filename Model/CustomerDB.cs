using System;
using Microsoft.EntityFrameworkCore;
using Model;

namespace customerApp.Model
{
    public class CustomerDB :DbContext

    {
        public CustomerDB(DbContextOptions<CustomerDB> options) :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customer> Customers { get; set; }

    }
}

