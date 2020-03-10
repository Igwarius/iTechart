using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.Services.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> GetRefreshToken(string username);

        Task DeleteRefreshToken(string username);

        Task SaveRefreshToken(string username, string newRefreshToken);
    }
}
