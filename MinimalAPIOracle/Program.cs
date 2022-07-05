using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Config;
using MinimalAPIOracle.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string StrConEnv = builder.Configuration.GetConnectionString("XEPDB1");
builder.Services.AddDbContext<ModelContext>(options => options.UseOracle(StrConEnv));

var app = builder.Build();
app.UseSwagger();

app.MapGet("ProductDetails/{customerId}", (ModelContext context, long customerId) =>
{
    var result = from customer in context.Customers
                 join orders in context.Orders
                    on customer.CustomerId equals orders.CustomerId
                 join ordersItems in context.OrderItems
                    on orders.OrderId equals ordersItems.OrderId
                 join products in context.Products
                    on ordersItems.ProductId equals products.ProductId
                 where customer.CustomerId == customerId
                 orderby ordersItems.Quantity
                 select new
                 {
                     customer.CustomerId,
                     orders.OrderId,
                     orders.Status,
                     ordersItems.UnitPrice,
                     ordersItems.Quantity,
                     products.Description
                 };
    return result.ToListAsync();              
});

app.UseSwaggerUI();
app.Run();
