using FarLibBLL.Authors.Mappers;
using FarLibBLL.Authors.Mappers.Interfaces;
using FarLibBLL.Authors.Services;
using FarLibBLL.Authors.Services.Interfaces;
using FarLibDAL.Authors.Repositories;
using FarLibDAL.Authors.Repositories.Interfaces;

namespace FarLibApi.Authors;

public static class ServicesExtension
{
    public static void AddAuthorServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();

        services.AddScoped<IAuthorService, AuthorService>();
        services.AddSingleton<IAuthorMapper, AuthorMapper>();
    }
}