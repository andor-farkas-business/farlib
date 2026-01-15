using FarLibDAL.Stocks.Repositories;
using FarLibDAL.Stocks.Repositories.Interfaces;

namespace FarLibApi.Stocks;

public static class ServicesExtension
{
    public static void AddStockServices(this IServiceCollection services)
    {
        services.AddScoped<IStockRepository, StockRepository>();
    }
}