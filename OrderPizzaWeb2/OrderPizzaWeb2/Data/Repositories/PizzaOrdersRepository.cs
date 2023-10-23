using Microsoft.EntityFrameworkCore;
using OrderPizzaWeb2.Data.Entities;

namespace OrderPizzaWeb2.Data.Repositories;

public interface IPizzaOrdersRepository
{
    Task<PizzaOrder?> GetAsync(int pizzaId);
    Task<IReadOnlyList<PizzaOrder?>> GetManyAsync();
    Task CreateAsync(PizzaOrder pizzaOrder);
    Task UpdateAsync(PizzaOrder pizzaOrder);
    Task DeleteAsync(PizzaOrder pizzaOrder);
}

public class PizzaOrdersRepository : IPizzaOrdersRepository
{
    private readonly OrderPizzaWebDbContext _orderPizzaWebDbContext;
    
    public PizzaOrdersRepository(OrderPizzaWebDbContext orderPizzaWebDbContext)
    {
        _orderPizzaWebDbContext = orderPizzaWebDbContext;
    }
    
    public async Task<PizzaOrder?> GetAsync(int pizzaId)
    {
        return await _orderPizzaWebDbContext.PizzaOrders
            .Include(o => o.PizzaToppings) 
            .ThenInclude(pt => pt.Topping) 
            .FirstOrDefaultAsync(o => o.Id == pizzaId);
    }

    public async Task<IReadOnlyList<PizzaOrder?>> GetManyAsync()
    {
        return await _orderPizzaWebDbContext.PizzaOrders
            .Include(o => o.PizzaToppings)
            .ThenInclude(pt => pt.Topping)
            .ToListAsync();
    }

    public async Task CreateAsync(PizzaOrder pizzaOrder)
    {
        _orderPizzaWebDbContext.PizzaOrders.Add(pizzaOrder);
        await _orderPizzaWebDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(PizzaOrder pizzaOrder)
    {
        _orderPizzaWebDbContext.PizzaOrders.Update(pizzaOrder);
        await _orderPizzaWebDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(PizzaOrder pizzaOrder)
    {
        _orderPizzaWebDbContext.PizzaOrders.Remove(pizzaOrder);
        await _orderPizzaWebDbContext.SaveChangesAsync();
    }
}