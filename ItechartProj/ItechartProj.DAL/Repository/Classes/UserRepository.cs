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
        private readonly Context.Context context;
        public UserRepository(Context.Context context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Task.FromResult(context.Users);
        }
        public async Task<User> GetCurrentUser(string login)
        {
            var user = await context.Users.FindAsync(login);
            if (user != null) return user;
            return null;
        }
        public async Task AddUser(User user)
        {
            var existinguser = await context.Users.FirstOrDefaultAsync(x => x.Login == user.Login);

            if (existinguser == null)
            {

                context.Users.Add(user);
            }
            else
                throw new Exception();
            
            await context.SaveChangesAsync();
        }
        public async Task<User> CheckUser(User user)
        {
            var founduser = await context.Users.FirstOrDefaultAsync(x => x.Login == user.Login && x.Password == user.Password);
            if (founduser != null) return founduser;
            return null;
        }
    }
}
