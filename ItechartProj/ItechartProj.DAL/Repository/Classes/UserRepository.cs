using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItechartProj.DAL.Contexts;
using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItechartProj.DAL.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await Task.FromResult(_context.Users);
        }

        public async Task<User> GetCurrentUser(string login)
        {
            var user = await _context.Users.FindAsync(login);
            if (user != null) return user;
            return null;
        }

        public async Task AddUser(User user)
        {
            var existinguser = await _context.Users.FirstOrDefaultAsync(x => x.Login == user.Login);

            if (existinguser == null)
                _context.Users.Add(user);
            else
                throw new Exception();

            await _context.SaveChangesAsync();
        }

        public async Task<User> CheckUser(User user)
        {
            var founduser =
                await _context.Users.FirstOrDefaultAsync(x => x.Login == user.Login && x.Password == user.Password);
            if (founduser != null) return founduser;
            return null;
        }
    }
}