using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ItechartProj.DAL.Repository.Classes.NewsRepository;

namespace ItechartProj.Services.Interfaces
{
    public interface INewsSevice
    {
        Task<IEnumerable<News>> GetNews();
        Task AddNews(News news);
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<SubCategory>> GetSubCategories();
        Task<IEnumerable<News>> GetNewsByCategory(int categoryID);
        Task<IEnumerable<News>> GetNewsBySubCategory(int subCategoryID);
        Task<IEnumerable<SubCategory>> GetSubCategoryByCategory(int categoryID);
        Task<IEnumerable<News>> GetSortNews(SortParam sortparam);
        Task<IEnumerable<News>> GetNewssById(int Id);
    }
}
