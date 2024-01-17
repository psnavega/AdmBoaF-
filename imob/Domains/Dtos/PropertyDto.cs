using System;
namespace immob.Domains.Dtos
{
    public record PropertyDto(Guid Id, string Address, decimal RentAmount, bool IsAvailable, List<OwnerDto> Owners);
}

