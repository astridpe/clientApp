using System;
using Model;
using Microsoft.AspNetCore.Mvc;
using customerApp.Model;

namespace Controllers
{
    [Route("[controller]/[action]")]
    public class customerController : ControllerBase
    {
        private readonly CustomerDB _db;


        public customerController(CustomerDB db)
        {
            _db = db;
        }

        public bool Save(Customer customer)
        {
            try
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                List<Customer> allCustomers = _db.Customers.ToList();
                return allCustomers;

            }
            catch
            {
                return null;
            }
           
         }

        public bool Delete(int id)
        {
            try
            {
                Customer oneCustomer = _db.Customers.Find(id);
                _db.Customers.Remove(oneCustomer);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Customer GetOne(int id)
        {
            try
            {
                Customer oneCustomer = _db.Customers.Find(id);
                return oneCustomer;

            }
            catch
            {
                return null;
            }
        }

        public bool Edit(Customer editCustomer)
        {
            try
            {
                Customer oneCustomer = _db.Customers.Find(editCustomer.id);
                oneCustomer.name = editCustomer.name;
                oneCustomer.address = editCustomer.address;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}

