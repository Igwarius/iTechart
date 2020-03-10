using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ItechartProj.DAL.Models
{
   public class RefreshToken
    {
        [Key]
        [ForeignKey("User")]
        public string Login { get; set; }
        [Column(TypeName = "varchar(2000)")]
        public string Token { get; set; }

        public User User { get; set; }
    }
}
