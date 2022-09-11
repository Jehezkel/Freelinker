using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await appDbContext.Products.ToListAsync());
    }
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product requestBody)
    {
        await appDbContext.Products.AddAsync(requestBody);
        await appDbContext.SaveChangesAsync();

        return Ok(requestBody.Id);
    }
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [HttpGet("{ProductId}")]
    public async Task<IActionResult> GetProduct(int ProductId)
    {
        var prod = await appDbContext.Products.FindAsync(ProductId);
        if (prod is null)
            return NotFound();
        return Ok(prod);
    }
    [HttpDelete("{ProductId}")]
    public async Task<IActionResult> DeleteProduct(int ProductId)
    {
        var prod = await appDbContext.Products.FindAsync(ProductId);
        if (prod is null)
            return NotFound();
        appDbContext.Products.Remove(prod);
        await appDbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpPut("{ProductId}")]
    public async Task<IActionResult> UpdateProduct(int ProductId, [FromBody] Product product)
    {
        var prod = await appDbContext.Products.FindAsync(ProductId);
        if (prod is null)
            return NotFound();
        prod.EAN = product.EAN;
        prod.SKU = product.SKU;
        prod.Name = product.Name;
        appDbContext.Products.Update(prod);
        await appDbContext.SaveChangesAsync();
        return Ok();
    }
}