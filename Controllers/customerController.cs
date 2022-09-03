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

        public bool Save(Customer customer)
        {
            try
            {
                _customerDB.Add(customer);
                _customerDB.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public List<Customer> getAllCustomers()
        {
            try
            {
                List<Customer> allCustomers = _customerDB.Customers.ToList();
                return allCustomers;

            }
            catch
            {
                return null;
            }
           
         }
        
    }
}

