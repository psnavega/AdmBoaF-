using System;
using immob.Models;

namespace immob.Domains.Records.Property
{
    public record AddProperty(Guid OwnerId, Address Address, decimal RentAmount);
}

