using System.Text.Json.Serialization;

namespace OrderPizzaWeb2.Data.Entities;

public class PizzaOrder
{
    public int Id { get; set; }
    public string Size { get; set; }
    public decimal Price { get; set; }
    
    public ICollection<PizzaOrderTopping> PizzaToppings { get; set; } = new List<PizzaOrderTopping>();
}