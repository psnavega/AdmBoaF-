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
            var newOwner = await ownerRepository.Add(owner);
            var result = new OwnerDto(newOwner.Id, newOwner.Name);

            return result;
        }

        public async Task<List<OwnerDto>> GetAll()
        {
            var owners = await ownerRepository.GetAll();

            var ownersDtos = owners.Select(c => new OwnerDto(c.Id, c.Name)).ToList();

            return ownersDtos;
        }


        public async Task<OwnerDto> GetById(Guid id)
        {
            var owner = await ownerRepository.GetById(id) ?? throw new Exception($"Customer with ID {id} not found");
            var ownerDto = new OwnerDto(owner.Id, owner.Name);

            return ownerDto;
        }


        public async Task<OwnerDto> Update(Guid id, UpdateOwner owner)
        {
            var ownerUpdated = await ownerRepository.Update(id, owner) ?? throw new Exception($"Customer with ID {id} not found");
            var result = new OwnerDto(ownerUpdated.Id, ownerUpdated.Name);

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await ownerRepository.Delete(id);

            return result;
        }
    }
}


