using Core.API.DAL;
using Core.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Core.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly DatabaseContext _context;
        private readonly IJWTTokenAuth _jWTTokenAuth;

        public TokenController(IConfiguration config, DatabaseContext context, IJWTTokenAuth jWTTokenAuth)
        {
            _configuration = config;
            _context = context;
            _jWTTokenAuth = jWTTokenAuth;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserInfo _userData)
        {
            
            var token = _jWTTokenAuth.GenerateJWT(_userData);

            if (!string.IsNullOrWhiteSpace(token.Result))
            {
               // return new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(token.Result);
            }
            else
            {
                return BadRequest("invalid result");
            }
            
           
        }
    }
}
