using FarLibDAL.Database;
using FarLibPages.Authors;
using FarLibPages.Books;
using FarLibPages.Distributors;
using FarLibPages.Stocks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<FarLibDbContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddLogging();

// Add FarLib services to the container.
builder.Services.AddAuthorServices();
builder.Services.AddBookServices();
builder.Services.AddDistributorServices();
builder.Services.AddStockServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    await SeedDatabase.SeedDbContextAsync(services);
}

await app.RunAsync();
