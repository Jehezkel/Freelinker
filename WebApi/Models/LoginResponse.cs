namespace WebApi.Models;
public class LoginResponse
{
    public string token { get; set; }
    public DateTime validTo { get; set; }
    public LoginResponse(string token, DateTime validTo)
    {
        this.token = token;
        this.validTo = validTo;
    }
}