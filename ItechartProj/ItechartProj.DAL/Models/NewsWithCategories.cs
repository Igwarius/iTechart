using System;
using System.Collections.Generic;
using System.Text;

namespace ItechartProj.DAL.Models
{
    public class NewsWithCategories
    {
        public IEnumerable<News> News { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
