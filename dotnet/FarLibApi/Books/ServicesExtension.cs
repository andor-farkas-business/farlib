using FarLibBLL.Books.Mappers;
using FarLibBLL.Books.Mappers.Interfaces;
using FarLibBLL.Books.Services;
using FarLibBLL.Books.Services.Interfaces;
using FarLibDAL.Books.Repositories;
using FarLibDAL.Books.Repositories.Interfaces;

namespace FarLibApi.Books;

public static class ServicesExtension
{
    public static void AddBookServices(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();

        services.AddScoped<IBookService, BookService>();
        services.AddSingleton<IBookMapper, BookMapper>();
    }
}