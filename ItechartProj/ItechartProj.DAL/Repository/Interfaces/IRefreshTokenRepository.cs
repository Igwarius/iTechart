using System.Threading.Tasks;
using ItechartProj.DAL.Models;

namespace ItechartProj.DAL.Repository.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetRefreshToken(string username);
        Task DeleteRefreshToken(string username);
        Task SaveRefreshToken(string username, string newRefreshToken);
    }
}