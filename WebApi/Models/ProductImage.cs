using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;
public class ProductImage
{
    public int Id { get; set; }
    public string? FileName { get; set; }
    public string? StoredFileName { get; set; }
    [NotMapped]
    public string? ImgUrl { get; set; }
    public Product? Product { get; set; }
    public DateTime UploadDate { get; set; } = DateTime.Parse("2000-01-01");
}