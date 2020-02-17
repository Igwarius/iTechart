using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.DAL.Repository.Interfaces
{
    public  interface IRefreshTokensRepository
    {
        Task<RefreshTokens> GetRefreshToken(string Username);

        Task DeleteRefreshToken(string Username);

        Task SaveRefreshToken(string Username, string newRefreshToken);
    }
}
