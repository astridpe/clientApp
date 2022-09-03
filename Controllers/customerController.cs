using System;
using Model;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("[controller]/[action]")]
    public class customerController : ControllerBase
    {
        public List<Customer> getAllCustomers()
        {
            var customers = new List<Customer>();

            var customer1 = new Customer();
            customer1.name = "Per Hansen";
            customer1.address = "Osloveien 82";

            var customer2 = new Customer
            {
                name = "Lise Hansen",
                address = "Akersgaten 83"
            };

            customers.Add(customer1);
            customers.Add(customer2);

            return customers;
         }
        
    }
}

