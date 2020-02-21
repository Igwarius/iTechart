using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItechartProj.DAL.Models
{
   public class Tag
    {
        [Key]
        [StringLength(maximumLength: 15, MinimumLength = 3)]
        public string TagName { get; set; }
        public Tag()
        {
            NewsTags = new List<NewsTags>();
           
        }
        public List<NewsTags> NewsTags { get; set; }

    }
}
