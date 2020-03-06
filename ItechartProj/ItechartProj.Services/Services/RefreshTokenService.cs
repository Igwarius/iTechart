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

        public async Task<RefreshTokens> GetRefreshToken(string login)
        {
            var res = await refreshTokensRepository.GetRefreshToken(login);
            if (res == null) return null;

            RefreshTokens refreshTokens = new RefreshTokens
            {
                Login = res.Login,
                RefreshToken = res.RefreshToken
            };

            return refreshTokens;
        }

        public async Task DeleteRefreshToken(string login)
        {
            await refreshTokensRepository.DeleteRefreshToken(login);
        }

        public async Task SaveRefreshToken(string login, string newRefreshToken)
        {
            await refreshTokensRepository.SaveRefreshToken(login, newRefreshToken);
        }
    }
}
