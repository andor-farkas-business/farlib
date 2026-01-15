using FarLibDAL.Authors.Repositories;
using FarLibDAL.Authors.Repositories.Interfaces;

namespace FarLibApi.Authors;

public static class ServicesExtension
{
    public static void AddAuthorServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();
    }
}