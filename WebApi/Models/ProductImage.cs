namespace WebApi.Models;
public class ProductImage
{
    public int Id { get; set; }
    public string? FileName { get; set; }
    public string? StoredFileName { get; set; }
    public Product Product { get; set; } = null!;
}