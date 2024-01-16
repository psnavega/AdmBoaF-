using immob.Infra;
using immob.Models;
using Microsoft.EntityFrameworkCore;
using immob.Domains.Interfaces;
using immob.Domains.Records.Customer;

namespace immob.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Add(AddCustomer customer)
        {
            var newCustomer = new Customer(customer.Name);
            await _context.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer;
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync<Customer>();
        }

        public async Task<Customer> GetById(Guid id)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Customer> Update(Guid id, UpdateCustomer customer)
        {
            Customer customerOnDb = await GetById(id) ?? throw new Exception($"Customer to ID: {id} not found");

            customerOnDb.UpdateName(customer.Name);

            _context.Customers.Update(customerOnDb);
            _context.SaveChanges();

            return customerOnDb;
        }

        public async Task<bool> Delete(Guid id)
        {
            Customer customerOnDb = await GetById(id) ?? throw new Exception($"Customer to ID: {id} not found");

            _context.Customers.Remove(customerOnDb);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}

