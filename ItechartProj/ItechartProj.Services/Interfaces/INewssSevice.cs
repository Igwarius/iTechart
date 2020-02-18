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
    }
}
