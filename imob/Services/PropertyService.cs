using immob.Domains.Dtos;
using immob.Domains.Interfaces;
using immob.Domains.Records.Property;

namespace immob.Services
{
    public class PropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<PropertyDto> Add(AddProperty property)
        {
            var newProperty = await _propertyRepository.Add(property);
            var result = new PropertyDto(newProperty.Id, newProperty.Address, newProperty.RentAmount, newProperty.IsAvailable, newProperty.OwnerId);

            return result;
        }

        public async Task<List<PropertyDto>> GetAll()
        {
            var properties = await _propertyRepository.GetAll();

            var propertyDtos = properties.Select(p => new PropertyDto(p.Id, p.Address, p.RentAmount, p.IsAvailable, p.OwnerId)).ToList();

            return propertyDtos;
        }

        public async Task<PropertyDto> GetById(Guid id)
        {
            var property = await _propertyRepository.GetById(id) ?? throw new Exception($"Property with ID {id} not found");
            var propertyDto = new PropertyDto(property.Id, property.Address, property.RentAmount, property.IsAvailable, property.OwnerId);

            return propertyDto;
        }

        public async Task<PropertyDto> Update(Guid id, UpdateProperty property)
        {
            var propertyUpdated = await _propertyRepository.Update(id, property) ?? throw new Exception($"Property with ID {id} not found");
            var result = new PropertyDto(propertyUpdated.Id, propertyUpdated.Address, propertyUpdated.RentAmount, propertyUpdated.IsAvailable, propertyUpdated.OwnerId);

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _propertyRepository.Delete(id);

            return result;
        }
    }
}
