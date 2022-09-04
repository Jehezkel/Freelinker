using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.DAL;
using WebApi.Models;

namespace WebApi.Controllers;
[ApiController]
[Authorize]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext appDbContext;

    public ProductController(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    [HttpGet]
    [Authorize(Roles = "admin")]

    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(appDbContext.Products.ToList());
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product requestBody)
    {
        await appDbContext.Products.AddAsync(requestBody);
        await appDbContext.SaveChangesAsync();

        return Ok();
    }
}