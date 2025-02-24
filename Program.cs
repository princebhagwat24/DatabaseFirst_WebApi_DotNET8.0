using DatabaseFirstWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Dependency injection for DbContext
builder.Services.AddDbContext<MyDataBaseApproachContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDataBaseApproach")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DatabaseFirstWebApi", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DatabaseFirstWebApi v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

// Add error handling middleware here

app.UseAuthorization();

app.MapControllers();

app.Run();