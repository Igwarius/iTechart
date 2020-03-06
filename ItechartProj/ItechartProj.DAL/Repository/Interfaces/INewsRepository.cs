using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ItechartProj.DAL.Repository.Classes.NewsRepository;

namespace ItechartProj.DAL.Repository.Interfaces
{
   public interface INewsRepository
    {
        Task<IEnumerable<News>> GetNewss();
    
        Task AddNewss(News news);
        Task<IEnumerable<Category>> GetCatigories();
        Task<IEnumerable<SubCategory>> GetSubCatigories();
        Task<IEnumerable<SubCategory>> GetSubCatigoriesByCategory(int categoryID);
        Task<IEnumerable<News>> GetNewsByCategory(int categoryID);
        Task<IEnumerable<News>> GetNewsBySubCategory(int subCategoryID);
        Task<IEnumerable<News>> GetSortNewss(SortParam sortparam);
        Task<IEnumerable<News>> GetNewssById(int id);
    }
}
