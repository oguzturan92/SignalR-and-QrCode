using System.Reflection;
using Api.Hubs;
using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.Concrete;
using Data.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    builder.Services.AddCors(opt => { // SignalR Cors Politikası 1.adım
        opt.AddPolicy("CorsPolicy",builder => 
        {
            builder.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
        });
    });
    builder.Services.AddSignalR(); // SignalR 1.adım

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

    builder.Services.AddScoped<IContactService, ContactManager>();
    builder.Services.AddScoped<IContactDal, ContactDal>();

    builder.Services.AddScoped<INotificationService, NotificationManager>();
    builder.Services.AddScoped<INotificationDal, NotificationDal>();

    builder.Services.AddScoped<IOrderService, OrderManager>();
    builder.Services.AddScoped<IOrderDal, OrderDal>();

    builder.Services.AddScoped<IOrderLineService, OrderLineManager>();
    builder.Services.AddScoped<IOrderLineDal, OrderLineDal>();

    builder.Services.AddScoped<IMessageService, MessageManager>();
    builder.Services.AddScoped<IMessageDal, MessageDal>();

    builder.Services.AddScoped<IProductService, ProductManager>();
    builder.Services.AddScoped<IProductDal, ProductDal>();

    builder.Services.AddScoped<ISliderService, SliderManager>();
    builder.Services.AddScoped<ISliderDal, SliderDal>();

    builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
    builder.Services.AddScoped<ISocialMediaDal, SocialMediaDal>();

    builder.Services.AddScoped<ITableService, TableManager>();
    builder.Services.AddScoped<ITableDal, TableDal>();

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

    app.UseCors("CorsPolicy"); // Cors Policy 2.adımı

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

    app.MapHub<SignalRHub>("/signalrhub"); // SignalR 2.adım

app.Run();
