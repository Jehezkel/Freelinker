using System.ComponentModel.DataAnnotations;

namespace WebApi.Models;
public class RegisterRequest
{
    [Required]
    public string? EmailAddress { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? UserName { get; set; }
}