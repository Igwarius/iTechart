using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.Services.Interfaces
{
   public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsForNews(int newsId);
        Task  AddComments(Comment comment);
    }
}
