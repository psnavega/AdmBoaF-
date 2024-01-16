using immob.Domains.Interfaces;
using immob.Infra;
using immob.Repositories;
using immob.Services;
//using immob.Routes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<PropertyService>();
builder.Services.AddScoped<TenantService>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.AddRoutesCustomer();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

