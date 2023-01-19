using Core.API.Models;

namespace Core.API
{
    public interface IJWTTokenAuth
    {
         Task<string> GenerateJWT(UserInfo _userData);
    }
}
