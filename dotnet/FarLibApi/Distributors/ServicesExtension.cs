using FarLibDAL.Distributors.Repositories;
using FarLibDAL.Distributors.Repositories.Interfaces;

namespace FarLibApi.Distributors;

public static class ServicesExtension
{
    public static void AddDistributorServices(this IServiceCollection services)
    {
        services.AddScoped<IDistributorRepository, DistributorRepository>();
    }
}