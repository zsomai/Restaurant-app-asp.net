using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using tema2.Models;
using tema2.BL;
using tema2.DAO;

var builder = WebApplication.CreateBuilder(args);
///Dependency injection
builder.Services.AddDbContext<MyDbContext>();
builder.Services.AddScoped<IRepository<Meal>, MealRepository>();
builder.Services.AddScoped<IRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IRepository<MealOrder>, OrderMealRepository>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<MealService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<MealOrderService>();

//builder.Services.AddSingleton<>
// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
