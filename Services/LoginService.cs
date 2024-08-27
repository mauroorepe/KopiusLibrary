using KopiusLibrary.Model.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KopiusLibrary.Services
{
    public class LoginService : ILoginService
    {
        private List<User> Users = new List<User>
        {
            new User{Email="user", Password="user"}
        };

        private readonly IConfiguration configuration;
        public LoginService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Login(User user)
        {
            var loginUser = Users.SingleOrDefault(x=>x.Email == user.Email && x.Password==user.Password);

            if (loginUser == null)
            {
                return string.Empty;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
                Issuer= configuration["Jwt:Issuer"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }
    }
}
