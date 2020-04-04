using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItechartProj.DAL.Contexts;
using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ItechartProj.DAL.Repository.Classes
{
    public class NewsRepository : INewsRepository
    {
        public enum SortParam
        {
            Date,
            View
        }

        private readonly Context _context;

        public NewsRepository(Context contexts)
        {
            _context = contexts;
        }

        public async Task<IEnumerable<News>> GetNews()
        {
            return await Task.FromResult(_context.News.Where(x => x.IsArchived == false));
        }

        public async Task<IEnumerable<News>> GetNewsById(int id)
        {
            return await Task.FromResult(_context.News.Where(x => x.Id == id && x.IsArchived == false));
        }

        public async Task AddViews(int id)
        {
            _context.News.First(x => x.Id == id).Viewers =
                _context.News.First(x => x.Id == id).Viewers + 1;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<News>> GetSortNews(SortParam sortparam)
        {
            switch (sortparam)
            {
                case SortParam.Date:
                    return await Task.FromResult(_context.News.Where(x => x.IsArchived == false)
                        .OrderBy(x => x.UploadDate));
                case SortParam.View:
                    return await Task.FromResult(_context.News.Where(x => x.IsArchived == false)
                        .OrderByDescending(x => x.Viewers));
                default:
                    return null;
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await Task.FromResult(_context.Categories);
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategories()
        {
            return await Task.FromResult(_context.SubCategories);
        }

        public async Task ArchivedNews(int id)
        {
            _context.News.First(x => x.Id == id).IsArchived =
                true;
            await _context.SaveChangesAsync();
        }

        public async Task ReArchivedNews(int id)
        {
            _context.News.First(x => x.Id == id).IsArchived =
                false;
            await _context.SaveChangesAsync();
        }

        public async Task AddNews(News news)
        {
            var existingNews = await _context.News.FirstOrDefaultAsync(x => x.Id == news.Id);

            if (existingNews == null)
            {
                news.IsArchived = false;
                _context.News.Add(news);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<News>> GetNewsBySubCategory(int subCategoryId)
        {
            return await Task.FromResult(_context.News.Where(x =>
                x.SubCategoryId == subCategoryId && x.IsArchived == false));
        }

        public async Task<IEnumerable<News>> GetNewsByCategory(int categoryId)
        {
            var news = new List<News>();

            var subCategories = _context.SubCategories.Where(a => a.CategoryId == categoryId).Select(a => a.Id);
            foreach (var category in subCategories)
            {
                var oneSubCategoryNews = _context.News.Where(b => b.SubCategoryId == category && b.IsArchived == false)
                    .AsEnumerable();

                news = news.Concat(oneSubCategoryNews).ToList();
            }

            return await Task.FromResult(news);
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoriesByCategory(int categoryId)
        {
            return await Task.FromResult(_context.SubCategories.Where(x => x.CategoryId == categoryId));
        }

        public async Task AddLike(string login, int id)
        {
            var like = new Like
            {
                Id = id,
                Login = login
            };
            _context.Comments.Where(x => x.Id == id).FirstOrDefault().LikesCount =
                _context.Comments.Where(x => x.Id == id).FirstOrDefault().LikesCount +1;
            _context.Likes.Add(like);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Like>> GetLike(string login, int id)
        {
            return await Task.FromResult(_context.Likes.Where(x => x.Id == id && x.Login == login));
        }

        public async Task UnLike(string login, int id)
        {
            _context.Likes.Remove(_context.Likes.Where(x => x.Id == id && x.Login == login)
                .FirstOrDefault());
            _context.Comments.Where(x => x.Id == id).FirstOrDefault().LikesCount =
                _context.Comments.Where(x => x.Id == id).FirstOrDefault().LikesCount - 1;
            await _context.SaveChangesAsync();
        }
    }
}