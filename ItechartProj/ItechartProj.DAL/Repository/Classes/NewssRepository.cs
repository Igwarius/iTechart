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
   public class NewssRepository :INewssRepository
    {
        private readonly Context.Context contexts;
        public NewssRepository(Context.Context contexts)
        {
            this.contexts = contexts;
        }
        public async Task<IEnumerable<News>> GetNewss()
        {
            return await Task.FromResult(contexts.Newss);
        }
        public async Task<IEnumerable<News>> GetSortNewss(string sortparam)
        {
            if (sortparam == "date")
                return await Task.FromResult(contexts.Newss.OrderBy(x=>x.uploadDate));
            if (sortparam == "view")
                return await Task.FromResult(contexts.Newss.OrderByDescending(x => x.Viewers));
            else
                return null;
        }
        public async Task<IEnumerable<Category>> GetCatigories()
        {
            return await Task.FromResult(contexts.Categories);
        }
        public async Task<IEnumerable<SubCategory>> GetSubCatigories()
        {
            return await Task.FromResult(contexts.SubCategories);
        }
        public async Task AddNewss(News news)
        {
            var existingnews = await contexts.Newss.FirstOrDefaultAsync(x => x.Id == news.Id);

            if (existingnews == null)
            {

                contexts.Newss.Add(news);
            }

            await contexts.SaveChangesAsync();
        }
        public async Task<IEnumerable<News>> GetNewsBySubCategory(int SubCategoryID) {

            return await Task.FromResult(contexts.Newss.Where(x => x.SubCategoryId == SubCategoryID));
        }
        public async Task<IEnumerable<News>> GetNewsByCategory(int CategoryID)
        {
            List<News> news = new List<News>();

            var subCategories = contexts.SubCategories.Where(a => a.CategoryID == CategoryID).Select(a => a.Id);
            foreach (var category in subCategories)
            {
                var oneSubCategoryNews= contexts.Newss.Where(b => b.SubCategoryId == category).AsEnumerable();
              
               news = news.Concat(oneSubCategoryNews).ToList();
            }
            return await Task.FromResult( news);
          
        }

        public async Task<IEnumerable<SubCategory>> GetSubCatigoriesByCategory(int CategoryID)
        {
            return await Task.FromResult(contexts.SubCategories.Where(x => x.CategoryID == CategoryID));
        }
    }
    }

