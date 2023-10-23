namespace OrderPizzaWeb2.Data.Dtos;

public record ToppingDto(int Id, string Name);

public record CreateToppingDto(string Name);

public record UpdateToppingDto(int Id, string Name);