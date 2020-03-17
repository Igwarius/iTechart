using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItechartProj.DAL.Models
{
    public class Comment
    {
        [Key] public int Id { get; set; }
        [ForeignKey("User")] public string Login { get; set; }
        [ForeignKey("News")] public int NewsId { get; set; }

        [Required]
        [Column(TypeName = "varchar(1000)")]
        public string Text { get; set; }

        [Required] public int Likes { get; set; }
    }
}