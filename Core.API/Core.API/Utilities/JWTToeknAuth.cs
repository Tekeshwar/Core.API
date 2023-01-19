using Core.API.DAL;
using Core.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.API.Utilities
{
    public class JWTToeknAuth : IJWTTokenAuth
    {
        private readonly string key;
        public IConfiguration _configuration;
        private readonly IUserInfo _userInfo;
        public JWTToeknAuth(IConfiguration config, IUserInfo userInfo)
        {
            //this.key = key;
            _configuration = config;
            _userInfo = userInfo;             
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
        //private async Task<UserInfo> GetUser(string email, string password)
        //{
        //    return await _context.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        //}
        public async Task<string> GenerateJWT(UserInfo _userData)
        {
            
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                UserInfo user = await _userInfo.GetUserInfo(_userData.Email, _userData.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("DisplayName", user.DisplayName),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        
    }
}
