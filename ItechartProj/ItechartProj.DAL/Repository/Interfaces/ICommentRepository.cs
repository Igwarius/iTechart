using System.Collections.Generic;
using System.Threading.Tasks;
using ItechartProj.DAL.Models;

namespace ItechartProj.DAL.Repository.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsForNews(int newsId);
        Task AddComments(Comment comment);
    }
}