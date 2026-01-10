using FarLibDAL.Authors.Entities;
using FarLibDAL.Books.Entities;
using FarLibDAL.Distributors.Entities;
using FarLibDAL.Stocks.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarLibDAL.Database;

public static class DbContextModelBuilderExtensions
{
    public static void AddAuthorRelations(this ModelBuilder modelBuilder)
    {
        var author = modelBuilder.Entity<Author>();
        author.HasKey(a => a.Id);
        author.Property(a => a.Name).IsRequired();
        author.Property(a => a.Description).IsRequired(false);
        author.HasMany(a => a.Books)
            .WithMany(b => b.Authors)
            .UsingEntity(j => j.ToTable("AuthorBooks"));
    }

    public static void AddBookRelations(this ModelBuilder modelBuilder)
    {
        var book = modelBuilder.Entity<Book>();
        book.HasKey(b => b.Id);
        book.Property(b => b.Title).IsRequired();
        book.Property(b => b.Description).IsRequired();
        book.Property(b => b.Type).IsRequired();
        book.Property(b => b.Category).IsRequired();
    }

    public static void AddDistributorRelations(this ModelBuilder modelBuilder)
    {
        var distributor = modelBuilder.Entity<Distributor>();
        distributor.HasKey(d => d.Id);
        distributor.Property(d => d.Name).IsRequired();
        distributor.Property(d => d.Address).IsRequired();
        distributor.Property(d => d.Type).IsRequired();
    }

    public static void AddStockRelations(this ModelBuilder modelBuilder)
    {
        var stock = modelBuilder.Entity<Stock>();
        stock.HasKey(s => new { s.BookId, s.DistributorId });
        stock.Property(s => s.Amount).IsRequired();
        stock.HasOne(s => s.Book)
            .WithMany(b => b.Stocks)
            .HasForeignKey(s => s.BookId);
        stock.HasOne(s => s.Distributor)
            .WithMany(d => d.Stocks)
            .HasForeignKey(s => s.DistributorId);
    }
}