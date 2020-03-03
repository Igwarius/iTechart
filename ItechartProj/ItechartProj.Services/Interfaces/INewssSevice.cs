using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.Services.Interfaces
{
    public interface INewssSevice
    {
        Task<IEnumerable<News>> GetNews();
        Task AddNews(News news);
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<SubCategory>> GetSubCategories();
        Task<IEnumerable<News>> GetNewsByCategory(int CategoryID);
        Task<IEnumerable<News>> GetNewsBySubCategory(int SubCategoryID);
        Task<IEnumerable<SubCategory>> GetSubCategoryByCategory(int CategoryID);
        Task<IEnumerable<News>> GetSortNews(string sortparam);
    }
}
