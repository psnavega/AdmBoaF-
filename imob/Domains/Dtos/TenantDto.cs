using System;
namespace immob.Domains.Dtos
{
    public record TenantDto(Guid Id, string Name, string Email, List<Guid> RentedPropertyIds);

}

