using System;
using customerApp.Model;
using Microsoft.EntityFrameworkCore;

namespace customerApp.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDB _db;

        public CustomerRepository(CustomerDB db)
        {
            _db = db;
        }

        public async Task<bool> Save(Customer customer)
        {
            try
            {
                var newCustommerField = new Customers();
                newCustommerField.firstname = customer.firstname;
                newCustommerField.lastname = customer.lastname;
                newCustommerField.address = customer.address;

                var existingPostalAdress = await _db.PostalAddresses.FindAsync(customer.zipCode);
                if (existingPostalAdress == null)
                {

                    var newPostalAdressesField = new PostalAddresses();
                    newPostalAdressesField.zipCode = customer.zipCode;
                    newPostalAdressesField.city = customer.city;
                    newCustommerField.PostalAddress = newPostalAdressesField;
                }
                else
                {
                    newCustommerField.PostalAddress = existingPostalAdress;
                }
                _db.Customers.Add(newCustommerField);
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
                List<Customer> allCustomers = await _db.Customers.Select(c => new Customer
                {
                    id = c.id,
                    firstname = c.firstname,
                    lastname = c.lastname,
                    address = c.address,
                    zipCode = c.PostalAddress.zipCode,
                    city = c.PostalAddress.city
                }).ToListAsync();

                return allCustomers;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Customers oneCustomer = await _db.Customers.FindAsync(id);
                _db.Customers.Remove(oneCustomer);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Customer> GetOne(int id)
        {
            try
            {
                Customers oneCustomer = await _db.Customers.FindAsync(id);
                var getCustomer = new Customer()
                {
                    id = oneCustomer.id,
                    firstname = oneCustomer.firstname,
                    lastname = oneCustomer.lastname,
                    address = oneCustomer.address,
                    zipCode = oneCustomer.PostalAddress.zipCode,
                    city = oneCustomer.PostalAddress.city
                };

                return getCustomer;

            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Edit(Customer editCustomer)
        {
            try
            {
                Customers oneCustomer = await _db.Customers.FindAsync(editCustomer.id);
                if (oneCustomer.PostalAddress.zipCode != editCustomer.zipCode)
                {
                    var existingPostalAddress = _db.PostalAddresses.Find(editCustomer.id);
                    if (existingPostalAddress == null)
                    {
                        var newPostalAdressesField = new PostalAddresses();
                        newPostalAdressesField.zipCode = editCustomer.zipCode;
                        newPostalAdressesField.city = editCustomer.city;
                        oneCustomer.PostalAddress = newPostalAdressesField;
                    }
                    else
                    {
                        oneCustomer.PostalAddress = existingPostalAddress;
                    }
                }
                oneCustomer.firstname = editCustomer.firstname;
                oneCustomer.lastname = editCustomer.lastname;
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

