using immob.Domains.Dtos;
using immob.Domains.Interfaces;
using immob.Domains.Records.Customer;

namespace immob.Services
{
	public class CustomerService
	{
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CustomerDto> Add(AddCustomer customer)
        {
            var newCustomer = await _customerRepository.Add(customer);
            var result = new CustomerDto(newCustomer.Id, newCustomer.Name);

            return result;
        }

        public async Task<List<CustomerDto>> GetAll()
        {
            var customers = await _customerRepository.GetAll();

            var customerDtos = customers.Select(c => new CustomerDto(c.Id, c.Name)).ToList();

            return customerDtos;
        }


        public async Task<CustomerDto> GetById(Guid id)
        {
            var customer = await _customerRepository.GetById(id) ?? throw new Exception($"Customer with ID {id} not found");
            var customerDto = new CustomerDto(customer.Id, customer.Name);

            return customerDto;
        }


        public async Task<CustomerDto> Update(Guid id, UpdateCustomer customer)
        {
            var customerUpdated = await _customerRepository.Update(id, customer) ?? throw new Exception($"Customer with ID {id} not found");
            var result = new CustomerDto(customerUpdated.Id, customerUpdated.Name);

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _customerRepository.Delete(id);

            return result;
        }
    }
}


