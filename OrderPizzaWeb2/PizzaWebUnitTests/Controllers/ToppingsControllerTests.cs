using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using OrderPizzaWeb2.Data.Dtos;
using OrderPizzaWeb2.Data.Entities;
using OrderPizzaWeb2.Data.Repositories;

namespace UniTests.Controllers;

public class ToppingsControllerTests
{
    private readonly IToppingsRepository _toppingsRepository;
    public ToppingsControllerTests()
    {
        _toppingsRepository = A.Fake<IToppingsRepository>();
    }
    
    [Fact]
    public void ToppingsController_GetManyAsync_ReturnIEnumerableToppingDto()
    {
        var toppings = A.Fake<ICollection<ToppingDto>>();
        var controller = new ToppingsController(_toppingsRepository);
        
        var result = controller.GetMany();
        
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(Task<IEnumerable<ToppingDto>>));
    }

    [Fact]
    public void ToppingsController_GetAsync_ReturnActionResultToppingDto()
    {
        int toppingId = 1;
        var topping = A.Fake<ToppingDto>();
        var controller = new ToppingsController(_toppingsRepository);
        
        var result = controller.Get(toppingId);
        
        result.Should().NotBeNull();
        result.Should().BeOfType(typeof(Task<ActionResult<ToppingDto>>));
    }

    
}