using System.Reflection;
using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.Concrete;
using Data.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    builder.Services.AddDbContext<Context>();

    builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

    builder.Services.AddScoped<IAboutService, AboutManager>();
    builder.Services.AddScoped<IAboutDal, AboutDal>();

    builder.Services.AddScoped<IBannerService, BannerManager>();
    builder.Services.AddScoped<IBannerDal, BannerDal>();

    builder.Services.AddScoped<IBookingService, BookingManager>();
    builder.Services.AddScoped<IBookingDal, BookingDal>();

    builder.Services.AddScoped<ICategoryService, CategoryManager>();
    builder.Services.AddScoped<ICategoryDal, CategoryDal>();

    builder.Services.AddScoped<IProductService, ProductManager>();
    builder.Services.AddScoped<IProductDal, ProductDal>();

    builder.Services.AddScoped<ISliderService, SliderManager>();
    builder.Services.AddScoped<ISliderDal, SliderDal>();

    builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
    builder.Services.AddScoped<ITestimonialDal, TestimonialDal>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
