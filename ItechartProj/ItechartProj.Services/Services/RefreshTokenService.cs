using System.Threading.Tasks;
using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using ItechartProj.Services.Interfaces;

namespace WebServer.Services.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RefreshToken> GetRefreshToken(string login)
        {
            var res = await _refreshTokenRepository.GetRefreshToken(login);
            if (res == null) return null;

            var refreshToken = new RefreshToken
            {
                Login = res.Login,
                Token = res.Token
            };

            return refreshToken;
        }

        public async Task DeleteRefreshToken(string login)
        {
            await _refreshTokenRepository.DeleteRefreshToken(login);
        }

        public async Task SaveRefreshToken(string login, string newRefreshToken)
        {
            await _refreshTokenRepository.SaveRefreshToken(login, newRefreshToken);
        }
    }
}