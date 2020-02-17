using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.DAL.Repository.Interfaces
{
  public  interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetCurrentUser(string Username);
        Task AddUser(User user);
        Task<User> CheckUser(User user);
    }
}
