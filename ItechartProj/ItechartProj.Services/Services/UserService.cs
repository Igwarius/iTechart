using ItechartProj.Controllers;
using ItechartProj.DAL.Context;
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
        private readonly IRefreshTokenRepository _refreshTokensRepository;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IRefreshTokenRepository refreshTokensRepository)
        {
            this._userRepository = userRepository;
            this._refreshTokensRepository = refreshTokensRepository;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }
        public async Task<User> GetCurrentUser(string Username)
        {
            var founduser = await _userRepository.GetCurrentUser(Username);
            if (founduser == null) return null;

            return founduser;
        }
        public Task AddUser(User user)
        {
           return _userRepository.AddUser(new User
            {
               Login = user.Login,
                Password = HashFunc.GetHashFromPassword (
                user.Password),
                Role = "user"

            });
        }

        public async Task<object> CheckUser(User user)
        {
            var founduser = await _userRepository.CheckUser(new User { Login = user.Login, Password = HashFunc.GetHashFromPassword(user.Password),Role=user.Role });
            if (founduser == null) return null;

          

            var foundUser = new User
            {
                Login= founduser.Login,
                Password = founduser.Password,
             Role=founduser.Role
            };

            var identity = ClaimsService.GetIdentity(foundUser);
            if (identity == null) return null;

            var jwttoken = TokenService.CreateToken(identity);
            if (jwttoken != null)
            {
                var newRefreshToken = TokenService.GenerateRefreshToken();
                 await _refreshTokensRepository.SaveRefreshToken(founduser.Login, newRefreshToken);

                var tokens = new
                {
                    token = jwttoken,
                    refreshToken = newRefreshToken
                };
              

                return tokens;

            }
            return null;
        }

    }
}