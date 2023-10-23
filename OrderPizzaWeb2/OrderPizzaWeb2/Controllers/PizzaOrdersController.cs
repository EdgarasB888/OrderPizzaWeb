using Microsoft.AspNetCore.Mvc;
using OrderPizzaWeb2.CalculationsFactory;
using OrderPizzaWeb2.Data.Dtos;
using OrderPizzaWeb2.Data.Entities;
using OrderPizzaWeb2.Data.Repositories;

namespace OrderPizzaWeb2.Controllers;

[ApiController]
[Route("api/pizzaOrders")]
public class PizzaOrdersController : ControllerBase
{
    private readonly IPizzaOrdersRepository _pizzaOrdersRepository;
    
    public PizzaOrdersController(IPizzaOrdersRepository pizzaOrdersRepository)
    {
        _pizzaOrdersRepository = pizzaOrdersRepository;
    }
    
    public async Task<IEnumerable<PizzaOrdersDto>> GetMany()
    {
        var pizzaOrders = await _pizzaOrdersRepository.GetManyAsync();
        
        return pizzaOrders.Select(o => new PizzaOrdersDto(o.Id, o.Size, o.Price, o.PizzaToppings.Select(pt => pt.Topping).ToList()));
        
    }
    
    [HttpGet]
    [Route("{pizzaOrderId}")]
    public async Task<ActionResult<PizzaOrdersDto>> Get(int pizzaOrderId)
    {
        var pizzaOrder = await _pizzaOrdersRepository.GetAsync(pizzaOrderId);

        if (pizzaOrder == null)
        {
            return NotFound(new { message = $"Could not find pizza order with an Id of {pizzaOrderId}" });
        }
        
        return new PizzaOrdersDto(pizzaOrder.Id, pizzaOrder.Size, pizzaOrder.Price, pizzaOrder.PizzaToppings.Select(pt => pt.Topping).ToList());
    }

    [HttpPost]
    public async Task<ActionResult<PizzaOrdersDto>> Create(CreatePizzaOrderDto createPizzaOrderDto)
    {
        var newPizzaOrder = new PizzaOrder
        {
            Size = createPizzaOrderDto.Size,
            Price = createPizzaOrderDto.Price,
            PizzaToppings = createPizzaOrderDto.ToppingIds.Select(toppingId => new PizzaOrderTopping
            {
                ToppingId = toppingId
            }).ToList()
        };
        
        await _pizzaOrdersRepository.CreateAsync(newPizzaOrder);
        
        return CreatedAtAction("Get", new { pizzaOrderId = newPizzaOrder.Id }, newPizzaOrder);
    }

    [HttpPut]
    [Route("{pizzaOrderId}")]
    public async Task<ActionResult<PizzaOrdersDto>> Update(int pizzaOrderId, UpdatePizzaOrderDto updatePizzaOrderDto)
    {
        var pizzaOrder = await _pizzaOrdersRepository.GetAsync(pizzaOrderId);

        if (pizzaOrder == null)
        {
            return NotFound(new { message = $"Could not find pizza order with an Id of {pizzaOrderId}" });
        }
        
        pizzaOrder.Size = updatePizzaOrderDto.Size;
        pizzaOrder.Price = updatePizzaOrderDto.Price;
        
        pizzaOrder.PizzaToppings.Clear();
        pizzaOrder.PizzaToppings = updatePizzaOrderDto.ToppingIds
            .Select(toppingId => new PizzaOrderTopping
            {
                ToppingId = toppingId
            })
            .ToList();

        await _pizzaOrdersRepository.UpdateAsync(pizzaOrder);
        return new PizzaOrdersDto(pizzaOrder.Id, pizzaOrder.Size, pizzaOrder.Price, pizzaOrder.PizzaToppings.Select(pt => pt.Topping).ToList());
    }
    
    [HttpDelete]
    [Route("{pizzaOrderId}")]
    public async Task<ActionResult> Delete(int pizzaOrderId)
    {
        var pizzaOrder = await _pizzaOrdersRepository.GetAsync(pizzaOrderId);

        if (pizzaOrder == null)
        {
            return NotFound(new { message = $"Could not find pizza order with an Id of {pizzaOrderId}" });
        }

        await _pizzaOrdersRepository.DeleteAsync(pizzaOrder);

        return NoContent();
    }

    [HttpPost("calculateTotalCost")]
    public ActionResult<decimal> CalculateTotalCost([FromBody] CalculateTotalPizzaOrderCostDto calculateTotalPizzaOrderCostDto)
    {
        ICostCalculationFactory factory = new CostCalculationFactory();
        
        decimal totalCost = factory.CalculateCost(calculateTotalPizzaOrderCostDto.Size, calculateTotalPizzaOrderCostDto.Toppings);
        return totalCost;
    }
}