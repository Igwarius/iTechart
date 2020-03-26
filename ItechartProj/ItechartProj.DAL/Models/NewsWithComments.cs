using System;
using System.Collections.Generic;
using System.Text;

namespace ItechartProj.DAL.Models
{
    public class NewsWithComments
    {
        public List<News> News = new List<News>();
        public List<Comment> Comment = new List<Comment>();
    }
}
