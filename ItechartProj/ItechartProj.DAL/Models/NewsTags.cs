using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ItechartProj.DAL.Models
{
    public class NewsTags
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("News")]
        public int NewsId { get; set; }
        [ForeignKey("Tag")]
        public int TagName { get; set; }
    }
}
