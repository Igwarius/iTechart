using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using ItechartProj.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.Services.Services
{
    public class NewssService : INewssSevice
    {
        private readonly INewssRepository newssRepository;

        public NewssService(INewssRepository newssRepository)
        {
            this.newssRepository = newssRepository;

        }
        public async Task<IEnumerable<News>> GetNews()
        {
            return await newssRepository.GetNewss();
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await newssRepository.GetCatigories();
        }
        public Task AddNews(News news)
        {

            return newssRepository.AddNewss(new News
            {
                Id = news.Id,
                Image = news.Image,
                Name = news.Name,
                Text = news.Text,
                SubCategoryId = news.SubCategoryId,
                Viewers = news.Viewers
            }) ;
        }
        public async Task<IEnumerable<News>> GetNewsByCategory(int CategoryID) {
            return await newssRepository.GetNewsByCategory(CategoryID);
        
        }
    }
}

