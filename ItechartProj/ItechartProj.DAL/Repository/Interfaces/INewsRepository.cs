using System.Collections.Generic;
using System.Threading.Tasks;
using ItechartProj.DAL.Models;
using static ItechartProj.DAL.Repository.Classes.NewsRepository;

namespace ItechartProj.DAL.Repository.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetNews();
        Task AddNews(News news);
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<SubCategory>> GetSubCategories();
        Task<IEnumerable<SubCategory>> GetSubCategoriesByCategory(int categoryId);
        Task<IEnumerable<News>> GetNewsByCategory(int categoryId);
        Task<IEnumerable<News>> GetNewsBySubCategory(int subCategoryId);
        Task<IEnumerable<News>> GetSortNews(SortParam sortparam);
        Task<IEnumerable<News>> GetNewsById(int id);
        Task AddViews(int id);
        Task ArchivedNews(int id);
        Task ReArchivedNews(int id);
        Task AddLike(string login, int id);
        Task<IEnumerable<Like>> GetLike(string login, int id);
        Task UnLike(string login, int id);
    }
}