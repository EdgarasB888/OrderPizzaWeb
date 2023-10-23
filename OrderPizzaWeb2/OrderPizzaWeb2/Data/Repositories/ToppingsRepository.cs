using Microsoft.EntityFrameworkCore;
using OrderPizzaWeb2.Data.Entities;

namespace OrderPizzaWeb2.Data.Repositories;

public interface IToppingsRepository
{
    Task<Topping?> GetAsync(int toppingId);
    Task<IReadOnlyList<Topping?>> GetManyAsync();
    Task DeleteAsync(Topping topping);
}

public class ToppingsRepository : IToppingsRepository
{
    private readonly OrderPizzaWebDbContext _orderPizzaWebDbContext;
    
    public ToppingsRepository(OrderPizzaWebDbContext orderPizzaWebDbContext)
    {
        _orderPizzaWebDbContext = orderPizzaWebDbContext;
    }
    
    public async Task<Topping?> GetAsync(int toppingId)
    {
        return await _orderPizzaWebDbContext.Toppings.FirstOrDefaultAsync(o => o.Id == toppingId);
    }
    
    public async Task<IReadOnlyList<Topping?>> GetManyAsync()
    {
        return await _orderPizzaWebDbContext.Toppings.ToListAsync();
    }
    
    public async Task DeleteAsync(Topping topping)
    {
        _orderPizzaWebDbContext.Toppings.Remove(topping);
        await _orderPizzaWebDbContext.SaveChangesAsync();
    }
}