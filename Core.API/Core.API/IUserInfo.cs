using Core.API.DAL;
using Core.API.Models;

namespace Core.API
{
    public interface IUserInfo
    {       
        Task<UserInfo> GetUserInfo(string emailId, string password);
    }
}
