using immob.Infra;
using immob.Models;
using Microsoft.EntityFrameworkCore;
using immob.Domains.Interfaces;
using immob.Domains.Records.Owner;
using System;

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
            var newOwner = new Owner(owner.Name, owner.Email);
            await _context.AddAsync(newOwner);
            await _context.SaveChangesAsync();
            return newOwner;
        }

        public async Task<List<Owner>> GetAll()
        {
            return await _context.Owners.ToListAsync();
        }

        public async Task<Owner> GetById(Guid id)
        {
            return await _context.Owners.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Owner> Update(Guid id, UpdateOwner owner)
        {
            Owner ownerOnDb = await GetById(id) ?? throw new Exception($"Owner to ID: {id} not found");

            ownerOnDb.UpdateName(owner.Name);
            ownerOnDb.UpdateEmail(owner.Email);

            _context.Owners.Update(ownerOnDb);
            await _context.SaveChangesAsync();

            return ownerOnDb;
        }

        public async Task<bool> Delete(Guid id)
        {
            Owner ownerOnDb = await GetById(id) ?? throw new Exception($"Owner to ID: {id} not found");

            _context.Owners.Remove(ownerOnDb);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsEmailUnique(string email)
        {
            return !await _context.Owners.AnyAsync(o => o.Email == email);
        }
    }
}
