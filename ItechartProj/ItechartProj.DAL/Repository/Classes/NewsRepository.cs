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
        public async Task<IEnumerable<News>> GetNewss()
        {
            return await Task.FromResult(context.Newss);
        }
        public async Task<IEnumerable<News>> GetNewssById(int id)
        {
            return await Task.FromResult(context.Newss.Where(x=>x.Id==id));
        }
        public enum SortParam 
        {
            date,
            view
        }
        public async Task<IEnumerable<News>> GetSortNewss(SortParam sortparam)
        {
            if (sortparam == SortParam.date)
                return await Task.FromResult(context.Newss.OrderBy(x=>x.uploadDate));
            if (sortparam == SortParam.view)
                return await Task.FromResult(context.Newss.OrderByDescending(x => x.Viewers));
            else
                return null;
        }
        public async Task<IEnumerable<Category>> GetCatigories()
        {
            return await Task.FromResult(context.Categories);
        }
        public async Task<IEnumerable<SubCategory>> GetSubCatigories()
        {
            return await Task.FromResult(context.SubCategories);
        }
        public async Task AddNewss(News news)
        {
            var existingnews = await context.Newss.FirstOrDefaultAsync(x => x.Id == news.Id);

            if (existingnews == null)
            {

                context.Newss.Add(news);
            }

            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<News>> GetNewsBySubCategory(int SubCategoryID) {

            return await Task.FromResult(context.Newss.Where(x => x.SubCategoryId == SubCategoryID));
        }
        public async Task<IEnumerable<News>> GetNewsByCategory(int CategoryID)
        {
            List<News> news = new List<News>();

            var subCategories = context.SubCategories.Where(a => a.CategoryID == CategoryID).Select(a => a.Id);
            foreach (var category in subCategories)
            {
                var oneSubCategoryNews= context.Newss.Where(b => b.SubCategoryId == category).AsEnumerable();
              
               news = news.Concat(oneSubCategoryNews).ToList();
            }
            return await Task.FromResult( news);
          
        }

        public async Task<IEnumerable<SubCategory>> GetSubCatigoriesByCategory(int CategoryID)
        {
            return await Task.FromResult(context.SubCategories.Where(x => x.CategoryID == CategoryID));
        }
    }
    }

