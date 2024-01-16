namespace immob.Models
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }

        public Customer(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Active = true;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void Deactivate()
        {
            Active = false;
        }
    }
}

