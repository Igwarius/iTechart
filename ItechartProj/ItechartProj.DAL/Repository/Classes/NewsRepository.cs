using ItechartProj.DAL.Context;
using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ItechartProj.DAL.Repository.Classes
{
   public class NewsRepository :INewsRepository
    {
        private readonly Context.Context context;
        public NewsRepository(Context.Context contexts)
        {
            this.context = contexts;
        }
        public async Task<IEnumerable<News>> GetNews()
        {
            return await Task.FromResult(context.News);
        }
        public async Task<IEnumerable<News>> GetNewsById(int id)
        {
            return await Task.FromResult(context.News.Where(x=>x.Id==id));
        }
        public enum SortParam 
        {
            Date,
            View
        }
        public async Task<IEnumerable<News>> GetSortNews(SortParam sortparam)
        {
            switch (sortparam)
            {
                case SortParam.Date:
                    return await Task.FromResult(context.News.OrderBy(x=>x.UploadDate));
                case SortParam.View:
                    return await Task.FromResult(context.News.OrderByDescending(x => x.Viewers));
                default:
                    return null;
            }
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await Task.FromResult(context.Categories);
        }
        public async Task<IEnumerable<SubCategory>> GetSubCategories()
        {
            return await Task.FromResult(context.SubCategories);
        }
        public async Task AddNews(News news)
        {
            var existingNews = await context.News.FirstOrDefaultAsync(x => x.Id == news.Id);

            if (existingNews == null)
            {

                context.News.Add(news);
            }

            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<News>> GetNewsBySubCategory(int subCategoryId) {

            return await Task.FromResult(context.News.Where(x => x.SubCategoryId == subCategoryId));
        }
        public async Task<IEnumerable<News>> GetNewsByCategory(int categoryId)
        {
            var news = new List<News>();

            var subCategories = context.SubCategories.Where(a => a.CategoryId == categoryId).Select(a => a.Id);
            foreach (var category in subCategories)
            {
                var oneSubCategoryNews= context.News.Where(b => b.SubCategoryId == category).AsEnumerable();
              
               news = news.Concat(oneSubCategoryNews).ToList();
            }
            return await Task.FromResult( news);
          
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoriesByCategory(int categoryId)
        {
            return await Task.FromResult(context.SubCategories.Where(x => x.CategoryId == categoryId));
        }
    }
    }

