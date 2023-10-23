namespace OrderPizzaWeb2.Data.Entities;

public class Topping
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<PizzaOrderTopping> ToppingPizzas { get; set; } = new List<PizzaOrderTopping>();
}