﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItechartProj.DAL.Models
{
    public class SubCategory
    {
        public SubCategory()
        {
            News = new List<News>();
        }

        [Key] 
        public int Id { get; set; }
        public List<News> News { get; set; }
        [Required] 
        public string Name { get; set; }
        [ForeignKey("Category")] 
        public int CategoryId { get; set; }
    }
}