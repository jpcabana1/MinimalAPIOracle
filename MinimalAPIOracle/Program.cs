using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Config;
using MinimalAPIOracle.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string StrConEnv = builder.Configuration.GetConnectionString("XEPDB1");

builder.Services.AddSingleton<RawQueryRepository>();
builder.Services.AddTransient<ProductDetailsRepository>();
builder.Services.AddDbContext<ModelContext>(options => options.UseOracle(StrConEnv));

var app = builder.Build();
app.UseSwagger();

app.MapGet("Countries", async (ModelContext contexto) => await contexto.Countries.ToListAsync());
app.MapGet("ProductsDetails", async (ProductDetailsRepository repository) => await repository.GetProductDetailsAsync());

app.UseSwaggerUI();
app.Run();
