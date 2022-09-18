using System;
namespace customerApp.Model
{
    public class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CustomerDB>();

                // Delete and recreate the database for each seeding
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var postalAddress1 = new PostalAddresses { zipCode = "9000", city = "Tromsø" };
                var postalAddress2 = new PostalAddresses { zipCode = "0177", city = "Oslo" };

                var customer1 = new Customers { firstname = "Ole", lastname = "Hansen", address = "Osloveien 82", PostalAddress = postalAddress1 };
                var customer2 = new Customers { firstname = "Line", lastname = "Jensen", address = "Akersveien 72", PostalAddress = postalAddress2 };

                context.Customers.Add(customer1);
                context.Customers.Add(customer2);

                context.SaveChanges();
            }

           
        }

    }
}

