using System.Collections.Generic;
using System.Threading.Tasks;
using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using ItechartProj.Services.Interfaces;

namespace ItechartProj.Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task AddComments(Comment comment)
        {
            await _commentRepository.AddComments(new Comment
            {
                Id = comment.Id,
                LikesCount = 0,

                Login = comment.Login,
                NewsId = comment.NewsId,
                Text = comment.Text
            });
        }

        public async Task<IEnumerable<Comment>> GetCommentsForNews(int newsId)
        {
            return await _commentRepository.GetCommentsForNews(newsId);
        }
    }
}