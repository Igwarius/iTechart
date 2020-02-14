using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using ItechartProj.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;

        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userRepository.GetUsers();
        }
        public async Task<User> GetCurrentUser(string Username)
        {
            var founduser = await userRepository.GetCurrentUser(Username);
            if (founduser == null) return null;

            return founduser;
        }
        public Task AddUser(User user)
        {
            return userRepository.AddUser(new User
            {
                Login = user.Login,
                password = user.password,

            });
        }

    }
}