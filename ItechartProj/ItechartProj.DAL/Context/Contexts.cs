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
        public Contexts(DbContextOptions<Contexts> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }
        
    }
}
