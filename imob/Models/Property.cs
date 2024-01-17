using System;
using System.Collections.Generic;

namespace immob.Models
{
    public class Property
    {
        public Guid Id { get; init; }
        public Address Address { get; private set; }
        public decimal RentAmount { get; private set; }
        public bool IsAvailable { get; private set; }
        public Guid? TenantId { get; private set; }
        public Tenant? Tenant { get; private set; }
        public List<Owner> Owners { get; private set; }

        private Property() { }

        public Property(Address address, decimal rentAmount, List<Owner> owners)
        {
            Id = Guid.NewGuid();
            Address = address;
            RentAmount = rentAmount;
            IsAvailable = true;
            Owners = owners ?? new List<Owner>();
        }

        public void UpdateRentAmount(decimal rentAmount)
        {
            RentAmount = rentAmount;
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }

        public void RentTo(Tenant tenant)
        {
            IsAvailable = false;
            TenantId = tenant.Id;
            Tenant = tenant;
        }

        public void RemoveTenant()
        {
            IsAvailable = true;
            TenantId = null;
            Tenant = null;
        }

        public void AddOwner(Owner owner)
        {
            Owners.Add(owner);
        }

        public void RemoveOwner(Owner owner)
        {
            Owners.Remove(owner);
        }
    }
}
