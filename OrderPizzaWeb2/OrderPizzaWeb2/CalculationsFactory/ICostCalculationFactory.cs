using OrderPizzaWeb2.Data.Entities;

namespace OrderPizzaWeb2.CalculationsFactory;

public interface ICostCalculationFactory
{
    decimal CalculateCost(string size, List<Topping> toppings);
}