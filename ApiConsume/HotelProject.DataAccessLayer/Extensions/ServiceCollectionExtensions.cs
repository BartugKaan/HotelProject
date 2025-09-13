using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace HotelProject.DataAccessLayer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services)
    {
        services.AddScoped<IServicesDal, EfServiceDal>();
        services.AddScoped<IRoomDal, EfRoomDal>();
        services.AddScoped<IStaffDal, EfStaffDal>();
        services.AddScoped<ISubscribeDal, EfSubscribeDal>();
        services.AddScoped<ITestimonialDal, EfTestimonialDal>();
        services.AddScoped<IAboutDal, EFAboutDal>();
        services.AddScoped<IBookingDal, EfBookingDal>();
        services.AddScoped<IContactDal, EfContactDal>();
        services.AddScoped<IGuestDal, EfGuestDal>();

        return services;
    }
}
