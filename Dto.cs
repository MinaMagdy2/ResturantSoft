public class OrderItemDto
{
    public string FoodName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
}

public class ResWithOrderItemsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public string? ImagePath { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new();
}
public class OrderWithItemsDto
{
    public int Id { get; set; }
    public string ClientName { get; set; }
    public int TableNum { get; set; }
    public DateTime OrderDate { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new();
}
