using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using OrderPizzaWeb2.Data;
using OrderPizzaWeb2.Data.Entities;
using OrderPizzaWeb2.Data.Repositories;

namespace UniTests.Repositories;

public class PizzaOrdersRepositoryTests
{
    private async Task<OrderPizzaWebDbContext> GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<OrderPizzaWebDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        var databaseContext = new OrderPizzaWebDbContext(options);
        if (await databaseContext.PizzaOrders.CountAsync() <= 0)
        {
            for (int i = 0; i < 10; i++)
            {
                databaseContext.PizzaOrders.Add(
                    new PizzaOrder()
                    {
                        Size = "Small",
                        Price = 10.99m,
                        PizzaToppings = new List<PizzaOrderTopping>()
                        {
                            new PizzaOrderTopping()
                            {
                                PizzaOrderId = 1,
                                PizzaOrder = new PizzaOrder(),
                                ToppingId = 1,
                                Topping = new Topping()
                                {
                                    Name = "Salami",
                                    ToppingPizzas = new List<PizzaOrderTopping>()
                                }
                            }
                        }
                    });
                await databaseContext.SaveChangesAsync();
            }
        }

        return databaseContext;
    }
    
    [Fact]
    public async void PizzaOrdersRepository_GetAsync_ReturnsTaskPizzaOrder()
    {
        var pizzaOrderId = 1;
        var dbContext = await GetDatabaseContext();
        var pizzaOrdersRepository = new PizzaOrdersRepository(dbContext);

        var result = pizzaOrdersRepository.GetAsync(pizzaOrderId);

        result.Should().NotBeNull();
        result.Should().BeOfType<Task<PizzaOrder?>>();
    }
    
    [Fact]
    public async void PizzaOrdersRepository_GetManyAsync_ReturnsIReadOnlyListTaskPizzaOrder()
    {
        var dbContext = await GetDatabaseContext();
        var pizzaOrdersRepository = new PizzaOrdersRepository(dbContext);
        
        var result = pizzaOrdersRepository.GetManyAsync();
        
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IReadOnlyList<PizzaOrder?>>>();
    }
    
    [Fact]
    public async void PizzaOrdersRepository_DeleteAsync_DeletesPizzaOrder()
    {
        var dbContext = await GetDatabaseContext();
        var pizzaOrdersRepository = new PizzaOrdersRepository(dbContext);
        
        var pizzaOrderIdToDelete = 1;
        var pizzaOrderToDelete = await dbContext.PizzaOrders.FirstOrDefaultAsync(t => t.Id == pizzaOrderIdToDelete);

        await pizzaOrdersRepository.DeleteAsync(pizzaOrderToDelete);

        var deletedPizzaOrder = await dbContext.PizzaOrders.FirstOrDefaultAsync(t => t.Id == pizzaOrderIdToDelete);

        deletedPizzaOrder.Should().BeNull();
    }

    [Fact]
    public async void PizzaOrdersRepository_CreateAsync_CreatesPizzaOrder()
    {
        var dbContext = await GetDatabaseContext();
        var pizzaOrdersRepository = new PizzaOrdersRepository(dbContext);
        
        var newPizzaOrder = new PizzaOrder()
        {
            Size = "Medium",
            Price = 12.99m,
            PizzaToppings = new List<PizzaOrderTopping>()
            {
                new PizzaOrderTopping()
                {
                    PizzaOrderId = 11, 
                    ToppingId = 2, 
                    Topping = new Topping()
                    {
                        Name = "Mushrooms",
                        ToppingPizzas = new List<PizzaOrderTopping>()
                    }
                }
            }
        };
        
        await pizzaOrdersRepository.CreateAsync(newPizzaOrder);
            
        var createdPizzaOrder = await dbContext.PizzaOrders.FirstOrDefaultAsync(t => t.Id == newPizzaOrder.Id);

        createdPizzaOrder.Should().NotBeNull();
        createdPizzaOrder.Size.Should().Be("Medium");
        createdPizzaOrder.Price.Should().Be(12.99m);
    }
}