using immob.Infra;
using immob.Models;
using Microsoft.EntityFrameworkCore;
using immob.Domains.Interfaces;
using immob.Domains.Records.Tenant;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace immob.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AppDbContext _context;

        public TenantRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tenant> Add(AddTenant tenant)
        {
            var newTenant = new Tenant(tenant.Name, tenant.Email);
            await _context.AddAsync(newTenant);
            await _context.SaveChangesAsync();
            return newTenant;
        }

        public async Task<List<Tenant>> GetAll()
        {
            return await _context.Tenants.ToListAsync();
        }

        public async Task<Tenant> GetById(Guid id)
        {
            return await _context.Tenants.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tenant> Update(Guid id, UpdateTenant tenant)
        {
            Tenant tenantOnDb = await GetById(id) ?? throw new Exception($"Tenant to ID: {id} not found");

            tenantOnDb.UpdateName(tenant.Name);
            tenantOnDb.UpdateEmail(tenant.Email);

            _context.Tenants.Update(tenantOnDb);
            await _context.SaveChangesAsync();

            return tenantOnDb;
        }

        public async Task<bool> Delete(Guid id)
        {
            Tenant tenantOnDb = await GetById(id) ?? throw new Exception($"Tenant to ID: {id} not found");

            _context.Tenants.Remove(tenantOnDb);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
