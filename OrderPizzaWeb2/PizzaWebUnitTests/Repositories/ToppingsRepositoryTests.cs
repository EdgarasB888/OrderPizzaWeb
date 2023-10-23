using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using OrderPizzaWeb2.Data;
using OrderPizzaWeb2.Data.Entities;
using OrderPizzaWeb2.Data.Repositories;

namespace UniTests.Repositories;

public class ToppingsRepositoryTests
{
    private async Task<OrderPizzaWebDbContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<OrderPizzaWebDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var databaseContext = new OrderPizzaWebDbContext(options);
        databaseContext.Database.EnsureCreated();
        if (await databaseContext.Toppings.CountAsync() <= 0)
        {
            for (int i = 0; i < 10; i++)
            {
                databaseContext.Toppings.Add(
                    new Topping()
                    {
                        Name = "Salami",
                        ToppingPizzas = new List<PizzaOrderTopping>()
                        {
                            new PizzaOrderTopping()
                            {
                                PizzaOrderId = 1,
                                PizzaOrder = new PizzaOrder()
                                {
                                    Size = "Small",
                                    Price = 8,
                                    PizzaToppings = new List<PizzaOrderTopping>()
                                },
                                ToppingId = 1,
                                Topping = new Topping()
                            }
                        }
                    });
                await databaseContext.SaveChangesAsync();
            }
        }
        return databaseContext;
    }

    [Fact]
    public async void ToppingsRepository_Get_ReturnsTaskTopping()
    {
        var toppingId = 1;
        var dbContext = await GetDatabaseContext();
        var toppingsRepository = new ToppingsRepository(dbContext);

        var result = toppingsRepository.GetAsync(toppingId);

        result.Should().NotBeNull();
        result.Should().BeOfType<Task<Topping?>>();
    }

    [Fact]
    public async void ToppingsRepository_Get_ReturnsIReadOnlyListTaskTopping()
    {
        var dbContext = await GetDatabaseContext();
        var toppingsRepository = new ToppingsRepository(dbContext);
        
        var result = toppingsRepository.GetManyAsync();
        
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IReadOnlyList<Topping?>>>();
    }

    [Fact]
    public async void ToppingsRepository_DeleteAsync_DeletesTopping()
    {
        var dbContext = await GetDatabaseContext();
        var toppingsRepository = new ToppingsRepository(dbContext);
        
        var toppingIdToDelete = 1;
        var toppingToDelete = await dbContext.Toppings.FirstOrDefaultAsync(t => t.Id == toppingIdToDelete);

        await toppingsRepository.DeleteAsync(toppingToDelete);

        var deletedTopping = await dbContext.Toppings.FirstOrDefaultAsync(t => t.Id == toppingIdToDelete);

        deletedTopping.Should().BeNull();
    }
}