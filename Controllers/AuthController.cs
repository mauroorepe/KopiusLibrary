using KopiusLibrary.Model.Entities;
using KopiusLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KopiusLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService userService;

        public AuthController(ILoginService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Login")]
        //[AllowAnonymous]//Que es???

        public IActionResult Login(User user)//Que es IActionResult
        {
            var token = userService.Login(user);
            if (token == null || token == string.Empty)
            {
                return BadRequest(new { message = "Email or Password is incorrect" });
            }
            return Ok(token);
        }

    }
}

        //private readonly string secretKey;

        //public AuthController(IConfiguration config)
        //{
        //    secretKey=config.GetSection("Settings").GetSection("SecretKey").ToString();
        //}

        //[HttpPost]
        //[Route("Validate")]
        //public IActionResult Validate([FromBody] Client request)
        //{
        //    if (request.Email == "kopius@kopiustech.com" && request.Password == "123")
        //    {
        //        var keyBytes = Encoding.ASCII.GetBytes(secretKey);
        //        var claims = new ClaimsIdentity();

        //        claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Email));

        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = claims,
        //            Expires = DateTime.UtcNow.AddMinutes(10),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)

        //        };

        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

        //        var createdToken = tokenHandler.WriteToken(tokenConfig);

        //        return StatusCode(StatusCodes.Status200OK, new { token = createdToken });
        //    }
        //    else
        //    { 
        //        return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
        //    }
        //}