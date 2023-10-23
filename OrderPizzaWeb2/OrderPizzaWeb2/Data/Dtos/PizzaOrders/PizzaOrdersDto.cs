using OrderPizzaWeb2.Data.Entities;

namespace OrderPizzaWeb2.Data.Dtos;

public record PizzaOrdersDto(int Id, string Size, decimal Price, List<Topping> Toppings);
public record CreatePizzaOrderDto(string Size, decimal Price, List<int> ToppingIds);
public record UpdatePizzaOrderDto(string Size, decimal Price, List<int> ToppingIds);
public record CalculateTotalPizzaOrderCostDto(string Size, List<Topping> Toppings);