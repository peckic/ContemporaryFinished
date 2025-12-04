using Microsoft.EntityFrameworkCore;
using FinalProjectIzzy.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FinalProjectIzzyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinalProjectIzzyContext") ?? throw new InvalidOperationException("Connection string 'FinalProjectIzzyContext' not found.")));

// register services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();

// enable Swagger UI at root: https://localhost:5001/
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = string.Empty; // serve UI at "/"
});

app.UseAuthorization();
app.MapControllers();
app.Run();