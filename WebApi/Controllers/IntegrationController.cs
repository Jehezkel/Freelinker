using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.DAL;
using WebApi.Models;

namespace WebApi.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class IntegrationController : ControllerBase
{
    private readonly AppDbContext context;
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly ILogger<IntegrationController> logger;
    private readonly UserManager<AppUser> userManager;

    public IntegrationController(AppDbContext context, IHttpContextAccessor httpContextAccessor, ILogger<IntegrationController> logger, UserManager<AppUser> userManager)
    {
        this.context = context;
        this.httpContextAccessor = httpContextAccessor;
        this.logger = logger;
        this.userManager = userManager;
    }
    [HttpPost]
    public async Task<IActionResult> SetIntegrationToken([FromBody] SetTokenRequest request)
    {
        var user = await userManager.GetUserAsync(this.httpContextAccessor.HttpContext.User);
        var appDest = this.context.IntegrationDests.FirstOrDefault(d => d.AppName == request.AppName);
        if (appDest is null)
        {
            return Problem("Application not found: ", request.AppName);
        }
        var existingToken = this.context.IntegrationTokens.FirstOrDefault(t => t.User == user && t.IntegrationDest == appDest);
        if (existingToken is not null)
        {
            existingToken.TokenValue = request.TokenvValue;
            logger.LogInformation("existing token", existingToken.ToString());
        }
        else
        {

            var result = new IntegrationToken
            {
                TokenValue = request.TokenvValue,
                IntegrationDest = appDest,
                User = user
            };
            this.context.IntegrationTokens.Add(result);
            logger.LogInformation("new token", result.ToString());
        }

        this.context.SaveChanges();
        return Ok();
    }
}