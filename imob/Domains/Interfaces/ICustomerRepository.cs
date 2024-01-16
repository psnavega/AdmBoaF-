using immob.Domains.Records.Customer;
using immob.Models;

namespace immob.Domains.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(Guid id);
        Task<Customer> Add(AddCustomer customer);
        Task<Customer> Update(Guid id, UpdateCustomer customer);
        Task<bool> Delete(Guid id);
    }
}
