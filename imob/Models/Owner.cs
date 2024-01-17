namespace immob.Models;
public class Owner
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public ICollection<PropertyOwner> OwnedProperties { get; set; }

    public Owner(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Active = true;
        OwnedProperties = new List<PropertyOwner>();
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


