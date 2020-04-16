using System;
using System.Collections.Generic;
using System.Text;

namespace ItechartProj.DAL.Models
{
    public class NewsWithComments
    {
        public IEnumerable<News> News { get; set; }
        public IEnumerable<Comment> Comment { get; set; }
    }
}
