
using Data.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

    // CONFIGURATION - START ------------------------------------------------------------------------------------
    builder.Services.AddDbContext<Context>();
    builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
    // CONFIGURATION - FINISH ------------------------------------------------------------------------------------

    // PROJE SEVİYESİNDE AUTHORİZE - START --------------------------------------------------------------------------------
    builder.Services.AddMvc(config => 
    {
        var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
        config.Filters.Add(new AuthorizeFilter(policy));
    });
    // PROJE SEVİYESİNDE AUTHORİZE - FINISH -------------------------------------------------------------------------------

    // RETURN LOGIN PAGE - START ------------------------------------------------------------------------------------
    builder.Services.ConfigureApplicationCookie(options => {
        options.LoginPath = "/User/Login";
    });
    // RETURN LOGIN PAGE - FINISH ------------------------------------------------------------------------------------

    // HTTPCLIENT - START ------------------------------------------------------------------------------------
    builder.Services.AddHttpClient();
    // HTTPCLIENT - FINISH ------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

    app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
