using AuthServer.Core;
using System.Threading.Tasks;

namespace AuthServer.Core
{
    public interface IUserService
    {
        Task<User> GetUserByUsername(string username);
        Task CreateUser(string username, string password);
        bool VerifyPassword(User user, string password);
        Task ChangePassword(User user, string newPassword);
        Task LockAccount(User user);
    }
}