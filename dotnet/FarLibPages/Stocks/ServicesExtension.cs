using FarLibBLL.Stocks.Mappers;
using FarLibBLL.Stocks.Mappers.Interfaces;
using FarLibBLL.Stocks.Services;
using FarLibBLL.Stocks.Services.Interfaces;
using FarLibDAL.Stocks.Repositories;
using FarLibDAL.Stocks.Repositories.Interfaces;

namespace FarLibPages.Stocks;

public static class ServicesExtension
{
    public static void AddStockServices(this IServiceCollection services)
    {
        services.AddScoped<IStockRepository, StockRepository>();

        services.AddScoped<IStockService, StockService>();
        services.AddSingleton<IStockMapper, StockMapper>();
    }
}