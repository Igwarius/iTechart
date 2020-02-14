using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItechartProj.DAL.Models
{
    public class User
    {
        [Key]
        [StringLength(maximumLength: 15, MinimumLength = 3)]
        public string Login { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 8)]
        public string password { get; set; }
    }
}
