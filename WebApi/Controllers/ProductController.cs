using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.DAL;
using WebApi.DTOs;
using WebApi.Models;
namespace WebApi.Controllers;
[ApiController]
[Authorize]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext appDbContext;
    private readonly IMapper mapper;
    private readonly IConfiguration config;
    private readonly ILogger<ProductController> logger;
    private string servedAt;

    public ProductController(AppDbContext appDbContext, IMapper mapper, IConfiguration config, ILogger<ProductController> logger)
    {
        this.appDbContext = appDbContext;
        this.mapper = mapper;
        this.config = config;
        this.logger = logger;
        this.servedAt = (config["uploadImage:servedAt"]).ToString();
        if (!servedAt.EndsWith('/'))
            servedAt = servedAt + "/";
    }
    private string imgUrlFromName(string fName) => servedAt + fName;
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductDTO>))]
    public async Task<IActionResult> GetAllProducts()
    {
        var entityList = await appDbContext.Products.Include(p => p.ProductImages).ToListAsync();
        var dtoList = mapper.Map<List<ProductDTO>>(entityList);

        dtoList.ForEach(p => p.MainImgUrl = imgUrlFromName(p.MainFileName ?? "empty.jpeg"));
        return Ok(dtoList);
    }
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product newProduct)
    {
        appDbContext.Attach<Product>(newProduct);
        // await appDbContext.Products.AddAsync(newProduct);
        //update images to contain assignment to productID

        await appDbContext.SaveChangesAsync();
        var prodDto = mapper.Map<ProductDTO>(newProduct);
        return Ok(prodDto);
    }
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
    [HttpGet("{ProductId}")]
    public async Task<IActionResult> GetProduct(int ProductId)
    {
        var prod = await appDbContext.Products.FindAsync(ProductId);
        if (prod is null)
            return NotFound();
        var prodDto = mapper.Map<ProductDTO>(prod);
        return Ok(prodDto);
    }
    [HttpDelete("{ProductId}")]
    public async Task<IActionResult> DeleteProduct(int ProductId)
    {
        var prod = await appDbContext.Products.Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.Id == ProductId);
        var destDir = Path.Join(Directory.GetCurrentDirectory(), config["uploadImage:destPath"]);
        if (prod is null)
            return NotFound();
        prod.ProductImages.ForEach(pi =>
        {
            var fullFilePath = Path.Join(destDir, pi.StoredFileName);
            if (System.IO.File.Exists(fullFilePath))
            {
                logger.LogInformation("deleting file", fullFilePath);
                System.IO.File.Delete(fullFilePath);
            }
            appDbContext.ProductImages.Remove(pi);
        });
        appDbContext.Products.Remove(prod);
        await appDbContext.SaveChangesAsync();
        return Ok();
    }
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
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
        var prodDto = mapper.Map<ProductDTO>(prod);
        return Ok(prodDto);
    }
}