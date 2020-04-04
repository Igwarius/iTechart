using System.Collections.Generic;
using System.Threading.Tasks;
using ItechartProj.DAL.Models;

namespace ItechartProj.DAL.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetCurrentUser(string username);
        Task AddUser(User user);
        Task<User> CheckUser(User user);
        Task BanUser(BannedUser bannedUser);
    }
}