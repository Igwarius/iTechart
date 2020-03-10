﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ItechartProj.DAL.Models
{
    public class News
    {
        public News()
        {
           
            Comments = new List<Comment>();
        }
        [Key]

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(1000)")]
        public string Text { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int Viewers { get; set; }
        [Required]
        public DateTime uploadDate { get; set; }

        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public List<Comment> Comments { get;set;}
   
    }
}