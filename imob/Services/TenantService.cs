using System;
using immob.Domains.Dtos;
using immob.Domains.Interfaces;
using immob.Domains.Records.Tenant;

namespace immob.Services
{
    public class TenantService
    {
        private readonly ITenantRepository _tenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<TenantDto> Add(AddTenant tenant)
        {
            var newTenant = await _tenantRepository.Add(tenant);
            var result = new TenantDto(newTenant.Id, newTenant.Name, newTenant.Email, new List<Guid>());

            return result;
        }

        public async Task<List<TenantDto>> GetAll()
        {
            var tenants = await _tenantRepository.GetAll();

            var tenantDtos = tenants.Select(t => new TenantDto(t.Id, t.Name, t.Email, t.RentedProperties.Select(p => p.Id).ToList())).ToList();

            return tenantDtos;
        }

        public async Task<TenantDto> GetById(Guid id)
        {
            var tenant = await _tenantRepository.GetById(id) ?? throw new Exception($"Tenant with ID {id} not found");
            var tenantDto = new TenantDto(tenant.Id, tenant.Name, tenant.Email, tenant.RentedProperties.Select(p => p.Id).ToList());

            return tenantDto;
        }

        public async Task<TenantDto> Update(Guid id, UpdateTenant tenant)
        {
            var tenantUpdated = await _tenantRepository.Update(id, tenant) ?? throw new Exception($"Tenant with ID {id} not found");
            var result = new TenantDto(tenantUpdated.Id, tenantUpdated.Name, tenantUpdated.Email, tenantUpdated.RentedProperties.Select(p => p.Id).ToList());

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _tenantRepository.Delete(id);

            return result;
        }
    }
}

