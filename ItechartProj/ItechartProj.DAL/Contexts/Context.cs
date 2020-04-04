using ItechartProj.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ItechartProj.DAL.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BannedUser> BannedUsers { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}