

using Microsoft.EntityFrameworkCore;
using tema2.Models;
namespace tema2.DAO;
public class MyDbContext : DbContext
{
    static readonly string connectionString = "Server=localhost; User ID=root; Password=rootroot; Database=restaurant";

    public DbSet<Meal> Meals { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<MealOrder> MealOrders { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}