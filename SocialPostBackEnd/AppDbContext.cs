using SocialPostBackEnd.Model;
using Microsoft.EntityFrameworkCore;

namespace SocialPostBackEnd
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Follow> Follow { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
