using immob.Domains.Records.Owner;
using immob.Models;

namespace immob.Domains.Interfaces
{
    public interface IOwnerRepository
    {
        Task<List<Owner>> GetAll();
        Task<Owner> GetById(Guid id);
        Task<Owner> Add(AddOwner owner);
        Task<Owner> Update(Guid id, UpdateOwner owner);
        Task<bool> Delete(Guid id);
        Task<bool> IsEmailUnique(string email);
    }
}
