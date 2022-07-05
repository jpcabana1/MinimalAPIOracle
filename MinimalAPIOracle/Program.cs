using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Config;
using MinimalAPIOracle.Repositories;
using MinimalAPIOracle.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string StrConEnv = builder.Configuration.GetConnectionString("XEPDB1");

builder.Services.AddTransient<ProductDetailsService>();
builder.Services.AddDbContext<ModelContext>(options => options.UseOracle(StrConEnv));

builder.Services.AddControllers(options =>
                 {
                     options.RespectBrowserAcceptHeader = true;
                 })
                 .AddJsonOptions(options =>
                 {
                     options.JsonSerializerOptions.PropertyNamingPolicy = null;
                 })
                 .AddXmlSerializerFormatters();

var app = builder.Build();
app.UseSwagger();

app.MapGet("ProductDetails/{customerId}.{format?}", [FormatFilter] (ProductDetailsService service, long customerId) => {
 return service.getProductDetails(customerId);
});

app.UseSwaggerUI();
app.Run();
