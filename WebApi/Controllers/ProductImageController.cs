using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using WebApi.DAL;
using WebApi.Models;
using System.Text.RegularExpressions;

namespace WebApi.Controllers;
[ApiController]
[Authorize]
[Route("[controller]")]
public class ProductImageController : ControllerBase
{
    private readonly ILogger<ProductImageController> logger;
    private readonly AppDbContext context;
    private readonly IConfiguration config;

    public ProductImageController(ILogger<ProductImageController> logger, AppDbContext context, IConfiguration config)
    {
        this.logger = logger;
        this.context = context;
        this.config = config;
    }
    [HttpPost("Upload")]
    [AllowAnonymous]
    public async Task<IActionResult> uploadImage(IFormFile file)
    {
        try
        {
            var destDir = Path.Join(Directory.GetCurrentDirectory(), config["uploadImage:destPath"]);
            if (!Directory.Exists(destDir))
            {
                logger.LogWarning("Dest path does not exists - creating :", destDir);
                Directory.CreateDirectory(destDir);
            }

            string destFileName = Guid.NewGuid().ToString();
            var extension = (Path.GetExtension(file.FileName));
            if (!Regex.IsMatch(extension.ToLower(), ".(png|jpg|jpeg)"))
            {
                return Problem("Unsupported extension - please upload images onlu in png/jpg/jpeg");
            }
            if (extension != null)
            {
                destFileName = $"{destFileName}{extension}";
            }
            ProductImage result = new ProductImage
            {
                StoredFileName = destFileName,
                FileName = file.FileName
            };
            var destPath = Path.Join(destDir, result.StoredFileName);
            using (FileStream fs = new FileStream(destPath, FileMode.CreateNew))
            {
                await file.CopyToAsync(fs);
            }
            context.ProductImages.Add(result);
            await context.SaveChangesAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Problem("Problem occured during file upload " + ex.Message);
        }
    }
}