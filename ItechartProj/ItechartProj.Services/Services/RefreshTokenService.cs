using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using ItechartProj.Services.Interfaces;
using System.Threading.Tasks;

namespace WebServer.Services.Services
{
    public class RefreshTokenService : IRefreshTokensService
    {
        private readonly IRefreshTokensRepository refreshTokensRepository;

        public RefreshTokenService(IRefreshTokensRepository refreshTokensRepository)
        {
            this.refreshTokensRepository = refreshTokensRepository;
        }

        public async Task<RefreshTokens> GetRefreshToken(string Login)
        {
            var res = await refreshTokensRepository.GetRefreshToken(Login);
            if (res == null) return null;

            RefreshTokens refreshTokens = new RefreshTokens
            {
                Login = res.Login,
                RefreshToken = res.RefreshToken
            };

            return refreshTokens;
        }

        public async Task DeleteRefreshToken(string Login)
        {
            await refreshTokensRepository.DeleteRefreshToken(Login);
        }

        public async Task SaveRefreshToken(string Login, string newRefreshToken)
        {
            await refreshTokensRepository.SaveRefreshToken(Login, newRefreshToken);
        }
    }
}
