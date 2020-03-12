using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ItechartProj.DAL.Repository.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ItechartProj.DAL.Repository.Classes
{
   public class CommentRepository:ICommentRepository
    {
        private readonly Context.Context context;
        public CommentRepository(Context.Context contexts)
        {
            this.context = contexts;
        }

        public async Task AddComments(Comment comment)
        { 
            var existingNews = await context.News.FirstOrDefaultAsync(x => x.Id == comment.Id);

                if (existingNews == null)
                { 
                    context.Comments.Add(comment);
                }

                await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsForNews(int newsId)
        {
            return await Task.FromResult(context.Comments.Where(x => x.NewsId == newsId));

        }


    }
}

