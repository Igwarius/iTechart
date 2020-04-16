using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItechartProj.DAL.Contexts;
using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItechartProj.DAL.Repository.Classes
{
    public class CommentRepository : ICommentRepository
    {
        private readonly Context _context;

        public CommentRepository(Context contexts)
        {
            _context = contexts;
        }

        public async Task AddComments(Comment comment)
        {
            var existingNews = await _context.News.FirstOrDefaultAsync(x => x.Id == comment.Id);

            if (existingNews == null)
            {
                _context.Comments.Add(comment);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsForNews(int newsId)
        {
            return await Task.FromResult(_context.Comments.Where(x => x.NewsId == newsId));
        }
    }
}