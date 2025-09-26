using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Services;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using HotelProject.WebUI.ValidationRules.SendMessageValidationRules;
using HotelProject.WebUI.ValidationRules.BookingValidationRules;
using HotelProject.WebUI.Extensions;
using HotelProject.WebUI.Middleware;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IValidator<CreateGuestDto>, CreateGuestValidator>();
builder.Services.AddTransient<IValidator<UpdateGuestDto>, UpdateGuestValidator>();
builder.Services.AddTransient<IValidator<CreateSendMessageDto>, CreateSendMessageValidator>();
builder.Services.AddTransient<IValidator<CreateBookingDto>, CreateBookingValidator>();
builder.Services.AddTransient<IValidator<UpdateBookingDto>, UpdateBookingValidator>();
builder.Services.AddControllersWithViews().AddFluentValidation();
builder.Services.AddHttpClient();

// Add Antiforgery
builder.Services.AddAntiforgery(options =>
{
    options.HeaderName = "X-CSRF-TOKEN";
    options.SuppressXFrameOptionsHeader = false;
});

// Add API Services
// Guest Services
builder.Services.AddScoped<GuestApiService>();
builder.Services.AddScoped<CreateGuestApiService>();
builder.Services.AddScoped<UpdateGuestApiService>();

// Staff Services
builder.Services.AddScoped<StaffApiService>();
builder.Services.AddScoped<AddStaffApiService>();
builder.Services.AddScoped<UpdateStaffApiService>();

// Service Services
builder.Services.AddScoped<ServiceApiService>();
builder.Services.AddScoped<CreateServiceApiService>();
builder.Services.AddScoped<UpdateServiceApiService>();

// Testimonial Services
builder.Services.AddScoped<TestimonialApiService>();
builder.Services.AddScoped<AddTestimonialApiService>();
builder.Services.AddScoped<UpdateTestimonialApiService>();

// Contact Services
builder.Services.AddScoped<ContactApiService>();
builder.Services.AddScoped<CreateContactApiService>();

// Booking Services
builder.Services.AddScoped<BookingApiService>();
builder.Services.AddScoped<CreateBookingApiService>();

// Room Services
builder.Services.AddScoped<RoomApiService>();
builder.Services.AddScoped<CreateRoomApiService>();
builder.Services.AddScoped<UpdateRoomApiService>();

// SendMessage Services
builder.Services.AddScoped<SendMessageApiService>();
builder.Services.AddScoped<CreateSendMessageApiService>();

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;

    // User settings
    options.User.RequireUniqueEmail = true;

    // Signin settings
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
})
.AddEntityFrameworkStores<Context>();

// Configure cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index";
    options.LogoutPath = "/Login/Logout";
    options.AccessDeniedPath = "/Login/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromHours(8);
    options.SlidingExpiration = true;
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
});

builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/500");
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Use custom middleware
app.UseMiddleware<SecurityHeadersMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Seed roles and admin user
await app.SeedRolesAndAdminAsync();

app.Run();
