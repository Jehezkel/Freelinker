namespace WebApi.Models;
public class Product
{
    public int Id { get; set; }
    public string? SKU { get; set; }
    public long EAN { get; set; }
    public string? Name { get; set; }
    public List<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
}