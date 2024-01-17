namespace immob.Models
{
	public class Tenant
	{
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public List<Property> RentedProperties { get; private set; }

        public Tenant(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            RentedProperties = new List<Property>();
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
        }

        public void RentProperty(Property property)
        {
            RentedProperties.Add(property);
        }

        public void VacateProperty(Property property)
        {
            RentedProperties.Remove(property);
        }
    }
}

