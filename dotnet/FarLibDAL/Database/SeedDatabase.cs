using FarLibCL.Authors.Entities;
using FarLibCL.Books.Entities;
using FarLibCL.Books.Enums;
using FarLibCL.Distributors.Entities;
using FarLibCL.Distributors.Enums;
using FarLibCL.Stocks.Entities;
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

        for (int i = 1; i <= 100; i++)
        {
            Authors.Add(new Author
            {
                Name = $"Author{i}",
                Description = $"Author{i} Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed lorem orci, dapibus in dignissim a, luctus id enim. Phasellus feugiat quam sit amet eleifend convallis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Quisque egestas ex at nisi egestas, et rhoncus magna ullamcorper. Morbi placerat ultrices turpis id egestas. Morbi dapibus ut magna ac ultricies. Maecenas convallis volutpat tellus, sit amet commodo arcu eleifend sit amet. Quisque et felis convallis, accumsan ante nec, posuere ligula. Maecenas non enim blandit purus vulputate imperdiet. Nulla tristique eros id consectetur viverra. Donec non sollicitudin felis. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Nullam efficitur luctus ligula ut vulputate. Sed efficitur velit sed aliquam dictum. Suspendisse quis magna enim. Praesent suscipit nisi eu odio fringilla posuere."
            });
        }
        await dbContext.Authors.AddRangeAsync(Authors);
        await dbContext.SaveChangesAsync();
        Authors = await dbContext.Authors.ToListAsync();

        Task[] tasks =
        [
          dbContext.Books.AddRangeAsync(Books),
          dbContext.Distributors.AddRangeAsync(Distributors),
        ];
        await Task.WhenAll(tasks);
        
        await dbContext.SaveChangesAsync();
        var books = await dbContext.Books.ToListAsync();
        var distributors = await dbContext.Distributors.ToListAsync();

        IList<Stock> stocks =
        [
            new Stock() {
                BookId = books.ElementAt(0).Id,
                DistributorId = distributors.ElementAt(0).Id,
                Amount = 15,
            }
        ];
        
        await dbContext.Stocks.AddRangeAsync(stocks);
        

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
    [];

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
}