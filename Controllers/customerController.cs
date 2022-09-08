using System;
using Model;
using Microsoft.AspNetCore.Mvc;
using customerApp.Model;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> Save(Customer customer)
        {
            try
            {
                _db.Customers.Add(customer);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            try
            {
                List<Customer> allCustomers = await _db.Customers.ToListAsync();
                return allCustomers;

            }
            catch
            {
                return null;
            }
           
         }

        public async Task <bool> Delete(int id)
        {
            try
            {
                Customer oneCustomer = await _db.Customers.FindAsync(id);
                _db.Customers.Remove(oneCustomer);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task <Customer> GetOne(int id)
        {
            try
            {
                Customer oneCustomer = await _db.Customers.FindAsync(id);
                return oneCustomer;

            }
            catch
            {
                return null;
            }
        }

        public async Task <bool> Edit(Customer editCustomer)
        {
            try
            {
                Customer oneCustomer = await _db.Customers.FindAsync(editCustomer.id);
                oneCustomer.name = editCustomer.name;
                oneCustomer.address = editCustomer.address;
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}

