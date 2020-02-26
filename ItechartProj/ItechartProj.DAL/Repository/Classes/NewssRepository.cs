using ItechartProj.DAL.Context;
using ItechartProj.DAL.Models;
using ItechartProj.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ItechartProj.DAL.Repository.Classes
{
   public class NewssRepository :INewssRepository
    {
        private readonly Contexts contexts;
        public NewssRepository(Contexts contexts)
        {
            this.contexts = contexts;
        }
        public async Task<IEnumerable<News>> GetNewss()
        {
            return await Task.FromResult(contexts.Newss.Where(x => x == x));
        }
        public async Task<IEnumerable<Category>> GetCatigories()
        {
            return await Task.FromResult(contexts.Categories.Where(x => x == x));
        }
        public async Task AddNewss(News news)
        {
            var existingnews = await contexts.Newss.FirstOrDefaultAsync(x => x.Id == news.Id);

            if (existingnews == null)
            {

                contexts.Newss.Add(news);
            }

            await contexts.SaveChangesAsync();
        }
    }
}
