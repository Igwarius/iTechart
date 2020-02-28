using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ItechartProj.DAL.Models
{
    public class Category
    {
        public Category()
        {
            SubCategories = new List<SubCategory>();
           
        }
        [Key]
        public int Id { get; set; }

        
        public List<SubCategory> SubCategories { get; set; }
        [Required]
        
        public string Name { get; set; }
      
    }
}
