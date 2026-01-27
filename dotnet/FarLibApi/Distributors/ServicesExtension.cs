using FarLibBLL.Distributors.Mappers;
using FarLibBLL.Distributors.Mappers.Interfaces;
using FarLibBLL.Distributors.Services;
using FarLibBLL.Distributors.Services.Interfaces;
using FarLibDAL.Distributors.Repositories;
using FarLibDAL.Distributors.Repositories.Interfaces;

namespace FarLibApi.Distributors;

public static class ServicesExtension
{
    public static void AddDistributorServices(this IServiceCollection services)
    {
        services.AddScoped<IDistributorRepository, DistributorRepository>();

        services.AddScoped<IDistributorService, DistributorService>();
        services.AddSingleton<IDistributorMapper, DistributorMapper>();
    }
}