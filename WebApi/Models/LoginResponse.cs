namespace WebApi.Models;
public class LoginResponse
{
    public string? token { get; set; }
    public string? validTo { get; set; }
}