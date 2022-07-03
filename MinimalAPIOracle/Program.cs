using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Config;
using MinimalAPIOracle.Repositories;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string StrConEnv = builder.Configuration.GetConnectionString("XEPDB1");

builder.Services.AddTransient<NativeQueryRepository>();

builder.Services.AddDbContext<ModelContext>
    (options => options.UseOracle(StrConEnv));

var app = builder.Build();
app.UseSwagger();

app.MapGet("Countries", async (ModelContext contexto) => await contexto.Countries.ToListAsync());

app.MapGet("Products", async (NativeQueryRepository repository) => await repository.GetProductDetails());

app.UseSwaggerUI();
app.Run();
