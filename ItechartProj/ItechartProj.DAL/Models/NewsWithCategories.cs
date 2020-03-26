using System;
using System.Collections.Generic;
using System.Text;

namespace ItechartProj.DAL.Models
{
    public class NewsWithCategories
    {
        public List<News> News = new List<News>();
        public List<Category> Categories = new List<Category>();
    }
}
