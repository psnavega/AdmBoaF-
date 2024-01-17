using immob.Domains.Dtos;
using immob.Domains.Interfaces;
using immob.Domains.Records.Property;

namespace immob.Services
{
    public class PropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IOwnerRepository _ownerRepository;

        public PropertyService(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository)
        {
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;
        }

        public async Task<PropertyDto> Add(AddProperty property)
        {
            var newProperty = await _propertyRepository.Add(property);
            var result = new PropertyDto(newProperty.Id, newProperty.Address, newProperty.RentAmount, newProperty.IsAvailable, newProperty.Owners.Select(o => new OwnerDto(o.Id, o.Name, o.Email)).ToList());

            return result;
        }

        public async Task<List<PropertyDto>> GetAll()
        {
            var properties = await _propertyRepository.GetAll();

            var propertyDtos = properties
                .Select(p => new PropertyDto(
                    p.Id,
                    p.Address,
                    p.RentAmount,
                    p.IsAvailable,
                    p.Owners.Select(o => new OwnerDto(o.Id, o.Name, o.Email)).ToList()
                ))
                .ToList();

            return propertyDtos;
        }


        public async Task<PropertyDto> GetById(Guid id)
        {
            var property = await _propertyRepository.GetById(id) ?? throw new Exception($"Property with ID {id} not found");
            var propertyDto = new PropertyDto(property.Id, property.Address, property.RentAmount, property.IsAvailable, property.Owners.Select(o => new OwnerDto(o.Id, o.Name, o.Email)).ToList());

            return propertyDto;
        }

        public async Task<PropertyDto> Update(Guid id, UpdateProperty property)
        {
            var propertyUpdated = await _propertyRepository.Update(id, property) ?? throw new Exception($"Property with ID {id} not found");
            var result = new PropertyDto(propertyUpdated.Id, propertyUpdated.Address, propertyUpdated.RentAmount, propertyUpdated.IsAvailable, propertyUpdated.Owners.Select(o => new OwnerDto(o.Id, o.Name, o.Email)).ToList());

            return result;
        }

        public async Task<PropertyDto> AddOwner(Guid propertyId, Guid ownerId)
        {
            var owner = await _ownerRepository.GetById(ownerId) ?? throw new Exception($"Owner with ID {ownerId} not found");
            var property = await _propertyRepository.GetById(propertyId) ?? throw new Exception($"Property with ID {propertyId} not found");

            if (owner == null || property == null)
            {
                throw new InvalidOperationException("Owner or propety cannot be found on database");
            }

            if (property.Owners.Any(o => o.Id == ownerId))
            {
                throw new InvalidOperationException($"Owner with ID {ownerId} is already associated with the property.");
            }

            property.AddOwner(owner);
            var propertyWithThisOwner = await _propertyRepository.Update(propertyId, new UpdateProperty(property.Address, property.RentAmount));
            var propertyDto = new PropertyDto(
                propertyWithThisOwner.Id,
                propertyWithThisOwner.Address,
                propertyWithThisOwner.RentAmount,
                propertyWithThisOwner.IsAvailable,
                propertyWithThisOwner.Owners.Select(owner => new OwnerDto(owner.Id, owner.Name, owner.Email)).ToList()
            );

            return propertyDto;
        }

        public async Task<PropertyDto> DeleteOwner(Guid propertyId, Guid ownerId)
        {
            var owner = await _ownerRepository.GetById(ownerId) ?? throw new Exception($"Owner with ID {ownerId} not found");
            var property = await _propertyRepository.GetById(propertyId) ?? throw new Exception($"Property with ID {propertyId} not found");

            if (owner == null || property == null)
            {
                throw new InvalidOperationException("Owner or property cannot be found in the database");
            }

            if (property.Owners.Count == 1 && property.Owners.Contains(owner))
            {
                throw new InvalidOperationException("Cannot remove the only owner of the property. Add another owner before removing this one.");
            }

            property.RemoveOwner(owner);
            var propertyWithoutThisOwner = await _propertyRepository.Update(propertyId, new UpdateProperty(property.Address, property.RentAmount));
            var propertyDto = new PropertyDto(
                propertyWithoutThisOwner.Id,
                propertyWithoutThisOwner.Address,
                propertyWithoutThisOwner.RentAmount,
                propertyWithoutThisOwner.IsAvailable,
                propertyWithoutThisOwner.Owners.Select(owner => new OwnerDto(owner.Id, owner.Name, owner.Email)).ToList()
            );

            return propertyDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _propertyRepository.Delete(id);

            return result;
        }
    }
}
