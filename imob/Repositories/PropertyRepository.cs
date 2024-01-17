using immob.Infra;
using immob.Models;
using Microsoft.EntityFrameworkCore;
using immob.Domains.Interfaces;
using immob.Domains.Records.Property;

namespace immob.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly AppDbContext _context;

        public PropertyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Property> Add(AddProperty property)
        {
            var owner = await _context.Owners.FindAsync(property.OwnerId) ?? throw new Exception($"Owner with ID {property.OwnerId} not found");
            var newProperty = new Property(property.Address, property.RentAmount, new List<Owner> { owner });

            await _context.AddAsync(newProperty);

            var propertyOwner = new PropertyOwner { PropertyId = newProperty.Id, OwnerId = owner.Id };
            owner.OwnedProperties.Add(propertyOwner);

            await _context.SaveChangesAsync();

            return newProperty;
        }

        public async Task<List<Property>> GetAll()
        {
            return await _context.Properties
                .Include(p => p.Address)
                .Include(p => p.Owners)
                .ToListAsync();
        }

        public async Task<Property> GetById(Guid id)
        {
            return await _context.Properties
                .Include(p => p.Address)
                .Include(p => p.Owners)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Property> Update(Guid id, UpdateProperty property)
        {
            Property propertyOnDb = await GetById(id) ?? throw new Exception($"Property to ID: {id} not found");

            propertyOnDb.UpdateAddress(property.Address);
            propertyOnDb.UpdateRentAmount(property.RentAmount);

            _context.Properties.Update(propertyOnDb);
            await _context.SaveChangesAsync();

            return propertyOnDb;
        }

        public async Task<bool> Delete(Guid id)
        {
            Property propertyOnDb = await GetById(id) ?? throw new Exception($"Property to ID: {id} not found");

            _context.Properties.Remove(propertyOnDb);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
