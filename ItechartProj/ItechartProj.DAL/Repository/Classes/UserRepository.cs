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
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Login == user.Login);

            if (existingUser == null)
                _context.Users.Add(user);
            else
                throw new Exception();

            await _context.SaveChangesAsync();
        }

        public async Task<User> CheckUser(User user)
        {
            var bannedUser = await _context.BannedUsers.FirstOrDefaultAsync(x => x.Login == user.Login);
            if (bannedUser != null)
                return null;
            var foundUser =
                await _context.Users.FirstOrDefaultAsync(x => x.Login == user.Login && x.Password == user.Password);
            if (foundUser != null) return foundUser;
            return null;
        }

        public async Task BanUser(BannedUser bannedUser)
        {
            var existingUser = await _context.BannedUsers.FirstOrDefaultAsync(x => x.Login == bannedUser.Login);

            if (existingUser == null)
                _context.BannedUsers.Add(bannedUser);
            else
                throw new Exception();

            await _context.SaveChangesAsync();
        }
    }
}