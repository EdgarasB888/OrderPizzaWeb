namespace OrderPizzaWeb2.Data.Entities;

public class PizzaOrderTopping
{
    public int Id { get; set; }
    public int? PizzaOrderId { get; set; }
    public PizzaOrder? PizzaOrder { get; set; }
    public int? ToppingId { get; set; }
    public Topping? Topping { get; set; }
}