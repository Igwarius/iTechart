using System.Threading.Tasks;
using ItechartProj.DAL.Contexts;
using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;

namespace ItechartProj.DAL.Repository.Classes
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly Context _commonContext;

        public RefreshTokenRepository(Context commonContext)
        {
            _commonContext = commonContext;
        }

        public async Task<RefreshToken> GetRefreshToken(string username)
        {
            var refreshToken = await _commonContext.RefreshTokens.FindAsync(username);
            return refreshToken;
        }

        public async Task DeleteRefreshToken(string username)
        {
            var refreshToken = await _commonContext.RefreshTokens.FindAsync(username);
            if (refreshToken != null)
            {
                _commonContext.Remove(refreshToken);
            }
            await _commonContext.SaveChangesAsync();
        }

        public async Task SaveRefreshToken(string login, string newRefreshToken)
        {
            var refreshToken = new RefreshToken {Login = login, Token = newRefreshToken};
            var existingTokens = await _commonContext.RefreshTokens.FindAsync(login);
            if (existingTokens != null)
            {
                _commonContext.RefreshTokens.Remove(existingTokens);
            }

            _commonContext.RefreshTokens.Add(refreshToken);
            await _commonContext.SaveChangesAsync();
        }
    }
}