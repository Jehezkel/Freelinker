using System.ComponentModel.DataAnnotations;

public class LoginRequest
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    public LoginRequest(string userName, string password)
    {
        this.UserName = userName;
        this.Password = password;
    }
}