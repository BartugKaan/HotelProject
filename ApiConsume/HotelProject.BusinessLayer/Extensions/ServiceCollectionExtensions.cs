using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace HotelProject.BusinessLayer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLayerServices(this IServiceCollection services)
    {
        services.AddScoped<IRoomService, RoomManager> ();
        services.AddScoped<IServiceService, ServiceManager> ();
        services.AddScoped<IStaffService, StaffManager> ();
        services.AddScoped<ISubscribeService, SubscribeManager> ();
        services.AddScoped<ITestimonialService, TestimonialManager> ();
        services.AddScoped<IAboutService, AboutManager> ();
        services.AddScoped<IBookingService, BookingManager> ();

        return services;
    }
}
