namespace immob.Models
{
	public class Customer
	{
		public Guid Id { get; init; }
		public string Name { get; private set; }
		public bool Active { get; private set; }

		public Customer(string name)
		{
			Name = name;
			Id = Guid.NewGuid();
			Active = true;
		}

		public void UpdateName(string name)
		{
			Name = name;
		}

		public void Deactive()
		{
			Active = false;
		}
	}
}

