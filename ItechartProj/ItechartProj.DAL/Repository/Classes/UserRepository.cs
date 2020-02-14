using ItechartProj.DAL.Context;
using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ItechartProj.DAL.Repository.Classes
{
  public  class UserRepository : IUserRepository
    {
        private readonly Contexts contexts;
        public UserRepository(Contexts contexts)
        {
            this.contexts = contexts;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Task.FromResult(contexts.Users.Where(x => x==x));
        }
        public async Task<User> GetCurrentUser(string Login)
        {
            var user = await contexts.Users.FindAsync(Login);
            if (user != null) return user;
            return null;
        }
        public async Task AddUser(User user)
        {
            var existinguser = await contexts.Users.FirstOrDefaultAsync(x => x.Login == user.Login);

            if (existinguser == null)
            {
               
                contexts.Users.Add(user);
            }

            await contexts.SaveChangesAsync();
        }
        public async Task<User> CheckUser(User user)
        {
            var founduser = await contexts.Users.FirstOrDefaultAsync(x => x.Login == user.Login && x.password == user.password);
            if (founduser != null) return founduser;
            return null;
        }
    }
}
