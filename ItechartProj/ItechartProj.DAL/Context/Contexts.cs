using ItechartProj.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace ItechartProj.DAL.Context
{
   public class Contexts:DbContext
    {
        public DbSet<RefreshTokens> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<News> Newss { get; set; }
        public DbSet<Comment> Comments { get; set; }
      
        public DbSet<Category> Categories { get; set; }
     
        public Contexts(DbContextOptions<Contexts> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }
        
    }
}
