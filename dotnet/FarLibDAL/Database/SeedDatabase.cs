using FarLibDAL.Authors.Entities;
using FarLibDAL.Books.Entities;
using FarLibDAL.Books.Enums;
using FarLibDAL.Distributors.Entities;
using FarLibDAL.Distributors.Enums;
using FarLibDAL.Stocks.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FarLibDAL.Database;

public static class SeedDatabase
{
    public static async Task SeedDbContextAsync(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<FarLibDbContext>();
        var logger = serviceProvider.GetRequiredService<ILogger<FarLibDbContext>>();

        await dbContext.Database.EnsureCreatedAsync();

        if (await dbContext.Authors.AnyAsync() || await dbContext.Distributors.AnyAsync())
        {
            return;
        }

        await dbContext.Authors.AddRangeAsync(Authors);
        await dbContext.SaveChangesAsync();
        Authors = await dbContext.Authors.ToListAsync();

        Task[] tasks =
        [
          dbContext.Books.AddRangeAsync(Books),
          dbContext.Distributors.AddRangeAsync(Distributors),
          dbContext.Stocks.AddRangeAsync(Stocks)
        ];
        
        await Task.WhenAll(tasks);

        await dbContext.SaveChangesAsync();

        var authorCount = dbContext.Authors.CountAsync();
        var bookCount = dbContext.Books.CountAsync();
        var distributorCount = dbContext.Distributors.CountAsync();
        var stockCount = dbContext.Stocks.CountAsync();

        logger.LogInformation(
            "\nAuthors: {AuthorCount}\nBooks: {BookCount}\nDistributors: {DistributorCount}\nStocks: {StockCount}",
            await authorCount,
            await bookCount,
            await distributorCount,
            await stockCount
        );
    }

    private static List<Author> Authors { get; set; } =
    [
        new Author()
        {
          Name = "Author1",
          Description = "Author1 Description",  
        },
        new Author()
        {
          Name = "Author2",
          Description = "Author2 Description",  
        },
    ];

    private static List<Book> Books =>
    [
        new Book()
        {
          Title = "Book1",
          Description = "Book1 Description",
          Type = BookType.Book,
          Category = BookCategory.Fantasy | BookCategory.Crime,
          Authors = [Authors[0]]  
        }
    ];

    private static List<Distributor> Distributors =>
    [
        new Distributor()
        {
            Name = "Distributor1",
            Address = "Distributor1 Address",
            Type = DistributorType.Library
        }
    ];

    private static List<Stock> Stocks =>
    [
        
    ];
}