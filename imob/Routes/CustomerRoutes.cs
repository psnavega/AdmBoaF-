//using immob.Domains.Records.Customer;
//using immob.Models;
//using Microsoft.EntityFrameworkCore;
//using immob.Domains.Dtos;
//using immob.Infra;

//namespace immob.Routes
//{

//    public static class CustomerRoutes
//    { 
//        public static void AddRoutesCustomer(this WebApplication app)
//        {
//            var routesCustomer = app.MapGroup("customers");

//            routesCustomer.MapPost("", async (AddCustomer req, AppDbContext context, CancellationToken ct) =>
//            {
//                var newCustomer = new Customer(req.Name);
//                await context.Customers.AddAsync(newCustomer, ct);
//                await context.SaveChangesAsync(ct);

//                var result = new CustomerDto(newCustomer.Id, newCustomer.Name);

//                return Results.Ok(result);
//            });

//            routesCustomer.MapGet("", async (AppDbContext context, CancellationToken ct) =>
//            {
//                var customers = await context
//                    .Customers
//                    .Where(customer => customer.Active)
//                    .Select(customer => new CustomerDto(customer.Id, customer.Name))
//                    .ToListAsync(ct);

//                return Results.Ok(customers);
//            });

//            routesCustomer.MapPatch("{id:guid}", async (Guid id, UpdateCustomer req, AppDbContext context, CancellationToken ct) =>
//            {
//                var customer = await context.Customers.SingleOrDefaultAsync(customer => customer.Id == id, ct);

//                if (customer == null) return Results.NotFound();

//                customer.UpdateName(req.Name);

//                await context.SaveChangesAsync(ct);

//                var result = new CustomerDto(customer.Id, customer.Name);

//                return Results.Ok(result);
//            });

//            routesCustomer.MapDelete("{id:guid}", async (Guid id, AppDbContext context, CancellationToken ct) =>
//            {
//                var customer = await context.Customers.FindAsync(id);

//                if (customer == null)
//                {
//                    return Results.NotFound();
//                }

//                context.Customers.Remove(customer);
//                await context.SaveChangesAsync(ct);

//                return Results.Ok(customer);
//            });
//        }
//    }
//}


