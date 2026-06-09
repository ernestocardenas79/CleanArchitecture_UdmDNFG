using CleanTeeth.Application.Contracts.Persistence;
using CleanTeeth.Application.Contracts.Repositories;
using CleanTeeth.Persistance.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanTeeth.Persistance;

public static class RegisterPersistenceServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<CleanTeethDbContext>(options =>
            options.UseSqlServer("YourConnectionStringHere"));

        services.AddScoped<IDentalOfficeRepository, IDentalOfficeRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWorkEFCore>();

        return services;
    }
}
