using System;
using immob.Models;

namespace immob.Domains.Dtos
{
    public record PropertyDto(Guid Id, Address Address, decimal RentAmount, bool IsAvailable, List<OwnerDto> Owners);
}

