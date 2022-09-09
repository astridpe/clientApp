using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using customerApp.Model;

namespace customerApp.Model
{
    public class Customers
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        virtual public PostalAddresses PostalAddress { get; set; }
    }

    public class PostalAddresses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string zipCode { get; set; }
        public string city { get; set; }

    }

    public class CustomerDB :DbContext

    {
        public CustomerDB(DbContextOptions<CustomerDB> options) :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<PostalAddresses> PostalAddresses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}

