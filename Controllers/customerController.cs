using System;
using Microsoft.AspNetCore.Mvc;
using customerApp.Model;
using Microsoft.EntityFrameworkCore;
using Castle.Core.Resource;
using customerApp.DAL;

namespace Controllers
{
    [Route("[controller]/[action]")]
    public class customerController : ControllerBase
    {
        private readonly ICustomerRepository _db;

        public customerController(ICustomerRepository db)
        {
            _db = db;
        }

        public async Task<bool> Save(Customer customer)
        {
            return await _db.Save(customer);
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _db.GetAllCustomers();
        }

        public async Task<bool> Delete(int id)
        {
            return await _db.Delete(id);
        }

        public async Task<Customer> GetOne(int id)
        {
            return await _db.GetOne(id);
        }

        public async Task<bool> Edit(Customer editCustomer)
        {
            return await _db.Edit(editCustomer);
        }

    }
}

