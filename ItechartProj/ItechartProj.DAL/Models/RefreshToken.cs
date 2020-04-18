using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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