using System;
namespace immob.Domains.Records.Property
{
	public record AddProperty(Guid OwnerId, string Address, decimal RentAmount);
}

