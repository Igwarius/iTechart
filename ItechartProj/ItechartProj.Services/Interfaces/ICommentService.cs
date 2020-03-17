using System.Collections.Generic;
using System.Threading.Tasks;
using ItechartProj.DAL.Models;

namespace ItechartProj.Services.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsForNews(int newsId);
        Task AddComments(Comment comment);
    }
}