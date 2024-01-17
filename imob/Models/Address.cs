using System;
namespace immob.Models
{
    public class Address
    {
        public Guid Id { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Number { get; private set; }

        public Address(string street, string city, string state, string zipCode, string number)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Number = number;
        }
    }
}

