using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using OrderPizzaWeb2.CalculationsFactory;
using OrderPizzaWeb2.Controllers;
using OrderPizzaWeb2.Data.Dtos;
using OrderPizzaWeb2.Data.Entities;
using OrderPizzaWeb2.Data.Repositories;

namespace UniTests.Controllers;

public class PizzaOrdersControllerTests
{
    private readonly IPizzaOrdersRepository _pizzaOrdersRepository;
    public PizzaOrdersControllerTests()
    {
        _pizzaOrdersRepository = A.Fake<IPizzaOrdersRepository>();
    }
    
    [Fact]
    public void PizzaOrdersController_GetManyAsync_ReturnIEnumerablePizzaOrdersDto()
    {
        var pizzaOrders = A.Fake<ICollection<PizzaOrdersDto>>();
        var controller = new PizzaOrdersController(_pizzaOrdersRepository);
        
        var result = controller.GetMany();
        
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(Task<IEnumerable<PizzaOrdersDto>>));
    }

    [Fact]
    public void PizzaOrdersController_GetAsync_ReturnActionResultPizzaOrdersDto()
    {
        int pizzaOrderId = 1;
        var topping = A.Fake<PizzaOrdersDto>();
        var controller = new PizzaOrdersController(_pizzaOrdersRepository);
        
        var result = controller.Get(pizzaOrderId);
        
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(Task<ActionResult<PizzaOrdersDto>>));
    }
}