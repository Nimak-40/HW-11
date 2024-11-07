namespace HW_11.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public decimal Price { get; set; }
}
