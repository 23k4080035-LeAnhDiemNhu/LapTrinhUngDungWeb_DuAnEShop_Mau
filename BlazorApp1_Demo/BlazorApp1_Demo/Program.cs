using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorApp1_Demo.Data;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.DataStore.HardCoded;
using eShop.UseCases.SearchProductScreen;
using eShop.UseCases.ShoppingCartScreen;
using eShop.CoreBusiness.Services;
using eShop.ShoppingCart.LocalStorage;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.StateStore.DI;
using eShop.UseCases.AdminPortalScreen;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

// Add Authentication & Authorization
builder.Services.AddAuthentication("eShop.CookieAuth")
    .AddCookie("eShop.CookieAuth", options =>
    {
        options.LoginPath = "/login";
    });
builder.Services.AddAuthorization();

// Register Clean Architecture Dependencies
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ISearchProduct, SearchProduct>();
builder.Services.AddTransient<IViewProduct, ViewProduct>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();
builder.Services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
builder.Services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
builder.Services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();
builder.Services.AddTransient<IViewOutstandingOrdersUseCase, ViewOutstandingOrdersUseCase>();
builder.Services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();
builder.Services.AddTransient<IViewOrderDetailUseCase, ViewOrderDetailUseCase>();
builder.Services.AddScoped<IShoppingCart, eShop.ShoppingCart.LocalStorage.ShoppingCart>();
builder.Services.AddScoped<IShoppingCartStateStore, ShoppingCartStateStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/auth/login", async (HttpContext context) =>
{
    var form = await context.Request.ReadFormAsync();
    var username = form["username"].ToString();
    var password = form["password"].ToString();

    if (username == "admin" && password == "admin")
    {
        var claims = new System.Collections.Generic.List<System.Security.Claims.Claim>
        {
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, username),
            new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, "Admin")
        };
        var identity = new System.Security.Claims.ClaimsIdentity(claims, "eShop.CookieAuth");
        var principal = new System.Security.Claims.ClaimsPrincipal(identity);
        await context.SignInAsync("eShop.CookieAuth", principal);
        context.Response.Redirect("/outstandingorders");
    }
    else
    {
        context.Response.Redirect("/login?error=invalid");
    }
});

app.MapGet("/auth/logout", async (HttpContext context) =>
{
    await context.SignOutAsync("eShop.CookieAuth");
    context.Response.Redirect("/login");
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
