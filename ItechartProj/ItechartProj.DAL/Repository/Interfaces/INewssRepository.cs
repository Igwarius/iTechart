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
    }
}
