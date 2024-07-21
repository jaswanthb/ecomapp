using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eCommerce.App.Helpers
{
    public class AuthService
    {
        public AuthService()
        {

        }
        public string Create(string userName, string password)
        {
            var user = GetUser(userName, password);
            var handler = new JwtSecurityTokenHandler();

            var privateKey = Encoding.UTF8.GetBytes(Helper.PrivateKey);

            var credentials = new SigningCredentials(new SymmetricSecurityKey(privateKey),
                                                     SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(1),
                Subject = GenerateClaims(user)
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(User user)
        {
            var ci = new ClaimsIdentity();

            ci.AddClaim(new Claim("id", user.Id.ToString()));
            ci.AddClaim(new Claim(ClaimTypes.Name, user.Username));
            ci.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));
            ci.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            foreach (var role in user.Roles)
                ci.AddClaim(new Claim(ClaimTypes.Role, role));

            return ci;
        }

        private User GetUser(string userName, string password)
        {
            return new User(1, "Jaswanth123", "Jaswanth B", "jaswanth@gmail.com", "Test@123", ["admin", "user"]);
        }
    }
}
