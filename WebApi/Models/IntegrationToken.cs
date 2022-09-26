namespace WebApi.Models;
public class IntegrationToken
{
    public int Id { get; set; }
    public AppUser User { get; set; }
    public IntegrationDest IntegrationDest { get; set; }
    public string? TokenValue { get; set; }
}