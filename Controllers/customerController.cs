using System;
using Model;
using Microsoft.AspNetCore.Mvc;
using customerApp.Model;

namespace Controllers
{
    [Route("[controller]/[action]")]
    public class customerController : ControllerBase
    {
        private readonly CustomerDB _customerDB;


        public customerController(CustomerDB customerDb)
        {
            _customerDB = customerDb;
        }

        public List<Customer> getAllCustomers()
        {
            List<Customer> allCustomers = _customerDB.Customers.ToList();
            return allCustomers;
         }
        
    }
}

