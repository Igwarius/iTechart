﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItechartProj.DAL.Models
{
    public class User
    {
        [Key]
        [StringLength(15, MinimumLength = 3)]
        public string Login { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}