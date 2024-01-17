using immob.Domains.Dtos;
using immob.Domains.Interfaces;
using immob.Domains.Records.Owner;

namespace immob.Services
{
	public class OwnerService
	{
        private readonly IOwnerRepository ownerRepository;

        public OwnerService(IOwnerRepository customerRepository)
        {
            ownerRepository = customerRepository;
        }

        public async Task<OwnerDto> Add(AddOwner owner)
        {
            if (!await IsEmailUnique(owner.Email))
            {
                throw new Exception("Email already exists.");
            }

            var newOwner = await ownerRepository.Add(owner);
            var result = new OwnerDto(newOwner.Id, newOwner.Name, newOwner.Email);

            return result;
        }

        public async Task<List<OwnerDto>> GetAll()
        {
            var owners = await ownerRepository.GetAll();

            var ownersDtos = owners.Select(c => new OwnerDto(c.Id, c.Name, c.Email)).ToList();

            return ownersDtos;
        }


        public async Task<OwnerDto> GetById(Guid id)
        {
            var owner = await ownerRepository.GetById(id) ?? throw new Exception($"Customer with ID {id} not found");
            var ownerDto = new OwnerDto(owner.Id, owner.Name, owner.Email);

            return ownerDto;
        }


        public async Task<OwnerDto> Update(Guid id, UpdateOwner owner)
        {
            if (!await IsEmailUnique(owner.Email))
            {
                throw new Exception("Email already exists.");
            }

            var ownerUpdated = await ownerRepository.Update(id, owner) ?? throw new Exception($"Customer with ID {id} not found");
            var result = new OwnerDto(ownerUpdated.Id, ownerUpdated.Name, ownerUpdated.Email);

            return result;
        }

        private async Task<bool> IsEmailUnique(string email)
        {
            return await ownerRepository.IsEmailUnique(email);
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await ownerRepository.Delete(id);

            return result;
        }
    }
}


