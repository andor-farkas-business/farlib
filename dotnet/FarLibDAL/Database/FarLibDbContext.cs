using FarLibCL.Authors.Entities;
using FarLibCL.Books.Entities;
using FarLibCL.Distributors.Entities;
using FarLibCL.Stocks.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarLibDAL.Database;

public class FarLibDbContext(DbContextOptions<FarLibDbContext> options) : DbContext(options)
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Distributor> Distributors { get; set; }
    public DbSet<Stock> Stocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddAuthorRelations();
        modelBuilder.AddBookRelations();
        modelBuilder.AddDistributorRelations();
        modelBuilder.AddStockRelations();
    }
}
