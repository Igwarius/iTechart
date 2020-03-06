using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.Services.Interfaces
{
   public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task AddUser(User user);
        Task<User> GetCurrentUser(string login);
        Task<object> CheckUser(User user);
    }
}
