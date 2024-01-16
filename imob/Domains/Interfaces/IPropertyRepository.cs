using immob.Domains.Records.Property;
using immob.Models;

namespace immob.Domains.Interfaces
{
    public interface IPropertyRepository
    {
        Task<Property> Add(AddProperty property);
        Task<List<Property>> GetAll();
        Task<Property> GetById(Guid id);
        Task<Property> Update(Guid id, UpdateProperty property);
        Task<bool> Delete(Guid id);
    }
}
