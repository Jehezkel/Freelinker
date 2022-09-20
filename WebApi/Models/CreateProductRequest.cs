namespace WebApi.Models;

public class CreateProductImage
{
    public int Id { get; set; }
    public string? StoredFileName { get; set; }
}

public class CreateProductRequest
{
    public int Id { get; set; }
    public string? SKU { get; set; }
    public long EAN { get; set; }
    public string? Name { get; set; }
    public IEnumerable<CreateProductImage> Images { get; set; } = new List<CreateProductImage>();
}