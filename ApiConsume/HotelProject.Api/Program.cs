using HotelProject.Api.Mapping;
using HotelProject.Api.Models;
using HotelProject.Api.Services;
using HotelProject.BusinessLayer.Extensions;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();
builder.Services.AddBusinessLayerServices();
builder.Services.AddDataAccessLayerServices();
builder.Services.AddAutoMapper(typeof(Program));

// Add Email Service
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("HotelProjectCors", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("HotelProjectCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
