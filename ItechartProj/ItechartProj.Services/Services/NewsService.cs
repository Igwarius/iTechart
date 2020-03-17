using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using ItechartProj.Services.Interfaces;
using static ItechartProj.DAL.Repository.Classes.NewsRepository;

namespace ItechartProj.Services.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task AddViews(int id)
        {
            await _newsRepository.AddViews(id);
        }

        public async Task<IEnumerable<News>> GetNews()
        {
            return await _newsRepository.GetNews();
        }

        public async Task<IEnumerable<News>> GetSortNews(SortParam sortparam)
        {
            return await _newsRepository.GetSortNews(sortparam);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _newsRepository.GetCategories();
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategories()
        {
            return await _newsRepository.GetSubCategories();
        }

        public Task AddNews(News news)
        {
            return _newsRepository.AddNews(new News
            {
                Id = news.Id,
                Image = news.Image,
                Name = news.Name,
                Text = news.Text,
                SubCategoryId = news.SubCategoryId,
                Viewers = news.Viewers,
                UploadDate = DateTime.Now
            });
        }

        public async Task<IEnumerable<News>> GetNewsByCategory(int categoryId)
        {
            return await _newsRepository.GetNewsByCategory(categoryId);
        }

        public async Task<IEnumerable<News>> GetNewsBySubCategory(int subCategoryId)
        {
            return await _newsRepository.GetNewsBySubCategory(subCategoryId);
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoryByCategory(int categoryId)
        {
            return await _newsRepository.GetSubCategoriesByCategory(categoryId);
        }

        public async Task<IEnumerable<News>> GetNewsById(int id)
        {
            return await _newsRepository.GetNewsById(id);
        }
    }
}