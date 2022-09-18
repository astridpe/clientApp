using System;
using System.Threading.Tasks;
using customerApp.Model;

namespace customerApp.DAL
{
    public interface ICustomerRepository
    {
        Task<bool> Save(Customer customer);
        Task<List<Customer>> GetAllCustomers();
        Task<bool> Delete(int id);
        Task<Customer> GetOne(int id);
        Task<bool> Edit(Customer editCustomer);

    }
}

