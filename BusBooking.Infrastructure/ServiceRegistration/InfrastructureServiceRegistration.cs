using BusBooking.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

public static class RegisterInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        //services.AddScoped<ILeaguesRepository,LeaguesRepository>();
        services.AddScoped(typeof(IBusBookingRepository<>), typeof(BusBookingRepository<>));
        return services;
    }
}