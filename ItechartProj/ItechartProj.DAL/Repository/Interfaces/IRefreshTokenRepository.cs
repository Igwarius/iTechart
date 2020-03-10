using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.DAL.Repository.Interfaces
{
    public  interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetRefreshToken(string username);

        Task DeleteRefreshToken(string username);

        Task SaveRefreshToken(string username, string newRefreshToken);
    }
}
