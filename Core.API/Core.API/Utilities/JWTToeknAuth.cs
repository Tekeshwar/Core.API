using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Core.API.Utilities
{
    public class JWTToeknAuth : IJWTTokenAuth
    {
        private readonly string key;
        public JWTToeknAuth(string key)
        {
            this.key = key;
        }

        //public string Authenticate(string username, string password)
        //{
        //    if (username == "admin" && password == "admin")
        //    {
        //        string issuer = "App URL";
        //        string audience = "App URL";
        //        var tokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MyConfidentialKey"));
        //        var signingCredentials = new SigningCredentials(tokenKey, SecurityAlgorithms.HmacSha256);
        //        var token = new JwtSecurityToken(issuer, audience, expires: DateTime.Now.AddMinutes(1), signingCredentials: signingCredentials);
        //        return new JwtSecurityTokenHandler().WriteToken(token);
        //    }
        //    return null;
        //}

        public string Authenticate(string username, string password)
        {

            return null;
        }
    }
}
