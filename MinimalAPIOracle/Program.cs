using Microsoft.EntityFrameworkCore;
using MinimalAPIOracle.Config;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string StrCon = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=GabinatorMobile)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=XEPDB1)));User Id=jpcabana;Password=otis2016;";

builder.Services.AddDbContext<Contexto>
    (options => options.UseOracle(StrCon));


var app = builder.Build();
app.UseSwagger();


app.MapGet("Countries",async (Contexto contexto) =>
{
     return await contexto.Countries.ToListAsync();
});



        

app.UseSwaggerUI();
app.Run();
