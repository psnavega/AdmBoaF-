using immob.Models;


namespace immob.Models;
public class Property
{
    public Guid Id { get; init; }
    public string Address { get; private set; }
    public decimal RentAmount { get; private set; }
    public bool IsAvailable { get; private set; }

    public Guid OwnerId { get; private set; }
    public Customer Owner { get; private set; }

    private Property() { }

    public Property(string address, decimal rentAmount, Customer owner)
    {
        Id = Guid.NewGuid();
        Address = address;
        RentAmount = rentAmount;
        IsAvailable = true;
        OwnerId = owner.Id;
        Owner = owner;
    }

    public void UpdateRentAmount(decimal rentAmount)
    {
        RentAmount = rentAmount;
    }

    public void UpdateAddress(string address)
    {
        Address = address;
    }

    public void RentTo(Tenant tenant)
    {
        IsAvailable = false;
    }
}
