using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.Services.Interfaces
{
    public interface IRefreshTokensService
    {
        Task<RefreshTokens> GetRefreshToken(string username);

        Task DeleteRefreshToken(string username);

        Task SaveRefreshToken(string username, string newRefreshToken);
    }
}
