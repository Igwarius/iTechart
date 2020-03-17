using System.Threading.Tasks;
using ItechartProj.DAL.Models;

namespace ItechartProj.Services.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<RefreshToken> GetRefreshToken(string username);
        Task DeleteRefreshToken(string username);
        Task SaveRefreshToken(string username, string newRefreshToken);
    }
}