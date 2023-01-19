using Core.API.DAL;
using Core.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.API.Repository
{
    public class UserInfoRepository : IUserInfo
    {
        readonly DatabaseContext _dbContext = new();
        public UserInfoRepository (DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserInfo> GetUserInfo(string email, string password)
        {
            return await _dbContext.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
