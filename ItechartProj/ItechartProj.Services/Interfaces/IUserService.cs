using System.Collections.Generic;
using System.Threading.Tasks;
using ItechartProj.DAL.Models;

namespace ItechartProj.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task AddUser(User user);
        Task<User> GetCurrentUser(string login);
        Task<Tokens> CheckUser(User user);
        Task BanUser(BannedUser user);
    }
}