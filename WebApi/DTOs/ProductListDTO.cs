using WebApi.Models;

namespace WebApi.DTOs;
public class ProductDTO
{
    public int Id { get; set; }
    public string? SKU { get; set; }
    public long EAN { get; set; }
    public string? Name { get; set; }
    public string? MainFileName { get; set; }
    public string? MainImgUrl { get; set; }
}
public class ProductListDTO
{

}