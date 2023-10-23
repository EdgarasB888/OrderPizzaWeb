using Microsoft.EntityFrameworkCore;
using OrderPizzaWeb2.Data.Entities;

namespace OrderPizzaWeb2.Data;

public class OrderPizzaWebDbContext : DbContext
{
    public OrderPizzaWebDbContext(DbContextOptions<OrderPizzaWebDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<PizzaOrder> PizzaOrders { get; set; }
    public DbSet<Topping> Toppings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PizzaOrder>().HasMany(x => x.PizzaToppings).WithOne(y => y.PizzaOrder)
            .OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<Topping>().HasMany(x => x.ToppingPizzas).WithOne(y => y.Topping)
            .OnDelete(DeleteBehavior.SetNull);
    }
}