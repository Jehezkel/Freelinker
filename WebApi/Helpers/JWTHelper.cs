using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.Models;

namespace WebApi.Helpers;
public class JWTHelper
{
    private readonly IConfiguration config;

    public JWTHelper(IConfiguration config)
    {
        this.config = config;
    }

    public JwtSecurityToken GetJwtSecurityToken(AppUser user, IList<string> userRoles)
    {
        var claims = new List<Claim>();
        claims.Add(new Claim("name", user.UserName));
        claims.Add(new Claim("mail", user.Email));
        foreach (var role in userRoles)
        {
            claims.Add(new Claim("role", role));
        }
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = TimeSpan.FromMinutes(Convert.ToInt32(config["JWT:ExpiresInMinutes"]));
        return new JwtSecurityToken(
            issuer: config["JWT:ValidIssuer"],
            audience: config["JWT:ValidAudience"],
            expires: DateTime.UtcNow.Add(expiration),
            claims: claims,
            signingCredentials: creds
        );
    }
}