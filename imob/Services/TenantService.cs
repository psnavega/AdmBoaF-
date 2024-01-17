using System;
using immob.Domains.Dtos;
using immob.Domains.Interfaces;
using immob.Domains.Records.Tenant;

namespace immob.Services
{
    public class TenantService
    {
        private readonly ITenantRepository _tenantRepository;
        private readonly IPropertyRepository _propertyRepository;

        public TenantService(ITenantRepository tenantRepository, IPropertyRepository propertyRepository)
        {
            _tenantRepository = tenantRepository;
            _propertyRepository = propertyRepository;
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

        public async Task<TenantDto> RentProperty(Guid tenantId, Guid propertyId)
        {
            var tenant = await _tenantRepository.GetById(tenantId) ?? throw new Exception($"Tenant with ID {tenantId} not found");
            var property = await _propertyRepository.GetById(propertyId) ?? throw new Exception($"Property with ID {propertyId} not found");

            if (tenant == null || property == null)
            {
                throw new InvalidOperationException("Tenant or propety cannot be found on database");
            }

            if (tenant.RentedProperties.Any())
            {
                throw new InvalidOperationException("Tenant already has a rented property. Cannot rent another property.");
            }
            else
            {
                tenant.RentProperty(property);
                var tenantWithPropertyRented = await _tenantRepository.Update(tenantId, new UpdateTenant(tenant.Name, tenant.Email));
                var tenantDto = new TenantDto(
                    tenantWithPropertyRented.Id,
                    tenantWithPropertyRented.Name,
                    tenantWithPropertyRented.Email,
                    tenantWithPropertyRented.RentedProperties.Select(p => p.Id).ToList()
                    );
                return tenantDto;
            }
        }

        public async Task<TenantDto> VacateProperty(Guid tenantId, Guid propertyId)
        {
            var tenant = await _tenantRepository.GetById(tenantId) ?? throw new Exception($"Tenant with ID {tenantId} not found");
            var property = await _propertyRepository.GetById(propertyId) ?? throw new Exception($"Property with ID {propertyId} not found");

            if (tenant == null || property == null)
            {
                throw new InvalidOperationException("Tenant or propety cannot be found on database");
            }

            tenant.VacateProperty(property);
            var tenantWithoutPropertyRented = await _tenantRepository.Update(tenantId, new UpdateTenant(tenant.Name, tenant.Email));
            var tenantDto = new TenantDto(
                tenantWithoutPropertyRented.Id,
                tenantWithoutPropertyRented.Name,
                tenantWithoutPropertyRented.Email,
                tenantWithoutPropertyRented.RentedProperties.Select(p => p.Id).ToList()
                );

            return tenantDto;
        }
    }
}

