using immob.Models;
using Microsoft.EntityFrameworkCore;

namespace immob.Infra;
public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Owner> Owners { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<PropertyOwner> PropertyOwners { get; set; }
    public DbSet<Address> Address { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = _configuration.GetConnectionString("DatabaseString");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string is not configured");
            }

            optionsBuilder.UseSqlServer(connectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }
}


