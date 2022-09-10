using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.DAL;
using WebApi.Helpers;
using WebApi.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<AppUser> userManager;
    private readonly SignInManager<AppUser> signInManager;
    private readonly IConfiguration configuration;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.configuration = configuration;
    }
    [HttpPost("Login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Login([FromBody] LoginRequest requestBody)
    {
        var user = await userManager.FindByNameAsync(requestBody.UserName);
        if (user == null)
        {
            return NotFound("User not found");
        }
        var passCheckResult = await signInManager.CheckPasswordSignInAsync(user, requestBody.Password, false);
        if (passCheckResult == SignInResult.Failed)
        {
            return BadRequest("Incorrect password");
        }
        else
        {
            var userRoles = await userManager.GetRolesAsync(user);
            var jwtHelper = new JWTHelper(configuration);
            var token = jwtHelper.GetJwtSecurityToken(user, userRoles);
            var tokenVal = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(
                new LoginResponse(tokenVal, token.ValidTo)
            );
        }
    }
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest requestBody)
    {
        var user = await userManager.FindByEmailAsync(requestBody.EmailAddress);
        if (user != null)
        {
            return Problem(detail: "User with specified email already exists - please recover your password and login.",
            statusCode: 400,
            title: "Registration failed - mail in use");
        }
        var registrationResult = await userManager.CreateAsync(new AppUser
        {
            Email = requestBody.EmailAddress,
            UserName = requestBody.UserName
        }, requestBody.Password);
        if (registrationResult == IdentityResult.Success)
        {
            return Ok("User created successfully");
        }
        else
        {
            return BadRequest(
            registrationResult.Errors);
        }

    }

}