using ItechartProj.DAL.Context;
using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.DAL.Repository.Classes
{
    public class RefreshTokensRepository : IRefreshTokensRepository
    {
        private readonly Context.Context commonContext;

        public RefreshTokensRepository(Context.Context commonContext)
        {
            this.commonContext = commonContext;
        }

        public async Task<RefreshTokens> GetRefreshToken(string username)
        {
            var RefreshToken = await commonContext.RefreshTokens.FindAsync(username);
            if (RefreshToken != null) return RefreshToken;
            return null;
        }

        public async Task DeleteRefreshToken(string username)
        {
            var RefreshToken = await commonContext.RefreshTokens.FindAsync(username);
            if (RefreshToken != null) commonContext.Remove(RefreshToken);
            await commonContext.SaveChangesAsync();
        }

        public async Task SaveRefreshToken(string login, string newRefreshToken)
        {
            RefreshTokens refreshToken = new RefreshTokens { Login = login, RefreshToken = newRefreshToken };
            var ExistingTokens = await commonContext.RefreshTokens.FindAsync(login);
            if (ExistingTokens != null) commonContext.RefreshTokens.Remove(ExistingTokens);

            commonContext.RefreshTokens.Add(refreshToken);
            await commonContext.SaveChangesAsync();
        }
    }
}
