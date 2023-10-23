using OrderPizzaWeb2.Data.Entities;

namespace OrderPizzaWeb2.CalculationsFactory;

public class CostCalculationFactory : ICostCalculationFactory
{
    public decimal CalculateCost(string size, List<Topping> toppings)
    {
        decimal baseCost = 0;
        
        switch (size.ToLower())
        {
            case "small":
                baseCost = 8.00m;
                break;
            case "medium":
                baseCost = 10.00m;
                break;
            case "large":
                baseCost = 12.00m;
                break;
            default:
                break;
        }
        
        decimal toppingsCost = toppings.Count;
        decimal totalCost = baseCost + toppingsCost;
        
        if (toppingsCost > 3)
        {
            totalCost = totalCost * 0.90m;
        }

        return totalCost;
    }
}