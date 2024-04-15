using BlogMe.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogMe.Data
{
    public class BlogMeDbContext:DbContext
    {
        public BlogMeDbContext(DbContextOptions<BlogMeDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostLike> BlogPostLike { get; set; }
        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}
