using immob.Domains.Records.Tenant;
using immob.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace immob.Domains.Interfaces
{
    public interface ITenantRepository
    {
        Task<Tenant> Add(AddTenant tenant);
        Task<List<Tenant>> GetAll();
        Task<Tenant> GetById(Guid id);
        Task<Tenant> Update(Guid id, UpdateTenant tenant);
        Task<bool> Delete(Guid id);
    }
}
