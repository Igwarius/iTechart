using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.DAL.Repository.Interfaces
{
  public  interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsForNews(int newsId);
        Task AddComments(Comment comment);
    }
}
