using FarLibDAL.Books.Repositories;
using FarLibDAL.Books.Repositories.Interfaces;

namespace FarLibApi.Books;

public static class ServicesExtension
{
    public static void AddBookServices(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
    }
}