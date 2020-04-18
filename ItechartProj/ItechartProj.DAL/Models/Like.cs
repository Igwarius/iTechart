using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ItechartProj.DAL.Models
{
    public class Like
    {
        [Key]
        public  int LikeId { get; set; }

        [ForeignKey("User")]
        public string Login { get; set; }
        [ForeignKey("Comment")]
        public int Id  { get; set; }
        public  User User { get; set; }
        public  Comment Comment { get; set; }
    }
}