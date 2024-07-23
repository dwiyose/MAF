using Microsoft.EntityFrameworkCore;
using Transaction.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddEnvironmentVariables();

// Debug: Log all configuration keys and values
foreach (var kvp in builder.Configuration.AsEnumerable())
{
    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
}

// Retrieve the connection string from the configuration
var connectionString = builder.Configuration.GetConnectionString("defaultConnection");

// Logging the connection string for debugging purposes
Console.WriteLine($"Connection String: {connectionString}");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string 'DefaultConnection' is not set.");
}

// Register the DbContext with the connection string
builder.Services.AddDbContext<TransactionDBContext>(options =>
    options.UseSqlServer(connectionString));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<TransactionDBContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
