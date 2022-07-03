using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Config;
using MinimalAPIOracle.Models;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string StrConEnv = builder.Configuration.GetConnectionString("XEPDB1");

builder.Services.AddDbContext<ModelContext>
    (options => options.UseOracle(StrConEnv));

var app = builder.Build();
app.UseSwagger();


app.MapGet("Countries",async (ModelContext contexto) =>
{
     return await contexto.Countries.ToListAsync();
});

app.MapGet("Products", async (ModelContext contexto) =>
{
    using (var command = contexto.Database.GetDbConnection().CreateCommand())
    {
        command.CommandText =
                     "SELECT "
                    + "    cus.customer_id, "
                    + "    ord.order_id, "
                    + "    ord.status,"
                    + "    ordi.unit_price, "
                    + "    ordi.quantity, "
                    + "    prod.description "
                    + "FROM CUSTOMERS cus "
                    + "INNER JOIN ORDERS ord "
                    + "    ON cus.customer_id = ord.customer_id "
                    + "LEFT JOIN ORDER_ITEMS ordi "
                    + "    ON ord.order_id = ordi.order_id "
                    + "INNER JOIN PRODUCTS prod "
                    + "    ON ordi.product_id = prod.product_id ";

        command.CommandType = CommandType.Text;
        contexto.Database.OpenConnection();

        using (var result = command.ExecuteReader())
        {
            var dataTable = new DataTable();
            dataTable.Load(result);
            
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"CUSTOMER_ID: {row["customer_id"]}, STATUS: {row["status"]}, DESCRIPTION: {row["description"]}");
            }
        }




    }
    return await contexto.Countries.ToListAsync();
});

        

app.UseSwaggerUI();
app.Run();
