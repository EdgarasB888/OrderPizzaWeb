using Microsoft.AspNetCore.Mvc;
using OrderPizzaWeb2.Data.Dtos;
using OrderPizzaWeb2.Data.Repositories;

[ApiController]
[Route("api/toppings")]
public class ToppingsController : ControllerBase
{
    private readonly IToppingsRepository _ToppingsRepository;
    
    public ToppingsController(IToppingsRepository ToppingsRepository)
    {
        _ToppingsRepository = ToppingsRepository;
    }
    
    public async Task<IEnumerable<ToppingDto>> GetMany()
    {
        var toppings = await _ToppingsRepository.GetManyAsync();

        return toppings.Select(o => new ToppingDto(o.Id, o.Name));
    }
    
    [HttpGet]
    [Route("{toppingId}")]
    public async Task<ActionResult<ToppingDto>> Get(int toppingId)
    {
        var topping = await _ToppingsRepository.GetAsync(toppingId);

        if (topping == null)
        {
            return NotFound(new { message = $"Could not find topping with an Id of {toppingId}" });
        }
        
        return new ToppingDto(topping.Id, topping.Name);
    }
    
    [HttpDelete]
    [Route("{toppingId}")]
    public async Task<ActionResult> Remove(int toppingId)
    {
        var topping = await _ToppingsRepository.GetAsync(toppingId);

        if (topping == null)
        {
            return NotFound(new { message = $"Could not find topping with an Id of {toppingId}" });
        }

        await _ToppingsRepository.DeleteAsync(topping);
        
        return NoContent();
    }
}