using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using ItechartProj.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ItechartProj.DAL.Repository.Classes.NewsRepository;

namespace ItechartProj.Services.Services
{
    public class NewssService : INewsSevice
    {
        private readonly INewsRepository newsRepository;

        public NewssService(INewsRepository newssRepository)
        {
            this.newsRepository = newssRepository;

        }

        public async Task<IEnumerable<News>> GetNews()
        {
            return await newsRepository.GetNewss();
        }
        public async Task<IEnumerable<News>> GetSortNews(SortParam sortparam)
        {
            return await newsRepository.GetSortNewss(sortparam);
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await newsRepository.GetCatigories();
        }
        public async Task<IEnumerable<SubCategory>> GetSubCategories()
        {
            return await newsRepository.GetSubCatigories();
        }
        public Task AddNews(News news)
        {

            return newsRepository.AddNewss(new News
            {
                Id = news.Id,
                Image = news.Image,
                Name = news.Name,
                Text = news.Text,
                SubCategoryId = news.SubCategoryId,
                Viewers = news.Viewers,
                uploadDate = DateTime.Now
            }); 
        }
        public async Task<IEnumerable<News>> GetNewsByCategory(int categoryID) {
            return await newsRepository.GetNewsByCategory(categoryID);
        
        }
     

        public async Task<IEnumerable<News>> GetNewsBySubCategory(int subCategoryID)
        {
            return await newsRepository.GetNewsBySubCategory(subCategoryID);
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoryByCategory(int categoryID)
        {
            return await newsRepository.GetSubCatigoriesByCategory(categoryID);
        }

        public async Task<IEnumerable<News>> GetNewssById(int id)
        {
            return await newsRepository.GetNewssById(id);
        }
    }
}

