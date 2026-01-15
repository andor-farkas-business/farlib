using System.Text.Json;
using System.Text.Json.Serialization;
using FarLibApi.Authors;
using FarLibApi.Books;
using FarLibApi.Distributors;
using FarLibApi.Middlewares;
using FarLibApi.Stocks;
using FarLibDAL.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FarLibDbContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddLogging();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Add FarLib services to the container.
builder.Services.AddAuthorServices();
builder.Services.AddBookServices();
builder.Services.AddDistributorServices();
builder.Services.AddStockServices();

// Add FarLib services to the container.
builder.Services.AddAuthorServices();
builder.Services.AddBookServices();
builder.Services.AddDistributorServices();
builder.Services.AddStockServices();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await SeedDatabase.SeedDbContextAsync(services);
}

await app.RunAsync();