using ItechartProj.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItechartProj.DAL.Repository.Interfaces
{
   public interface INewssRepository
    {
        Task<IEnumerable<News>> GetNewss();
    
        Task AddNewss(News news);
        Task<IEnumerable<Category>> GetCatigories();
        Task<IEnumerable<SubCategory>> GetSubCatigories();
        Task<IEnumerable<SubCategory>> GetSubCatigoriesByCategory(int CategoryID);
        Task<IEnumerable<News>> GetNewsByCategory(int CategoryID);
        Task<IEnumerable<News>> GetNewsBySubCategory(int SubCategoryID);
    }
}
