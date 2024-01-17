using immob.Infra;
using immob.Models;
using Microsoft.EntityFrameworkCore;
using immob.Domains.Interfaces;
using immob.Domains.Records.Owner;

namespace immob.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly AppDbContext _context;

        public OwnerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Owner> Add(AddOwner owner)
        {
            var newOwner = new Owner(owner.Name);
            await _context.AddAsync(newOwner);
            await _context.SaveChangesAsync();
            return newOwner;
        }

        public async Task<List<Owner>> GetAll()
        {
            return await _context.Owners.ToListAsync<Owner>();
        }

        public async Task<Owner> GetById(Guid id)
        {
            return await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Owner> Update(Guid id, UpdateOwner owner)
        {
            Owner ownerOnDb = await GetById(id) ?? throw new Exception($"Owner to ID: {id} not found");

            ownerOnDb.UpdateName(owner.Name);

            _context.Owners.Update(ownerOnDb);
            _context.SaveChanges();

            return ownerOnDb;
        }

        public async Task<bool> Delete(Guid id)
        {
            Owner ownersOnDb = await GetById(id) ?? throw new Exception($"Owner to ID: {id} not found");

            _context.Owners.Remove(ownersOnDb);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

