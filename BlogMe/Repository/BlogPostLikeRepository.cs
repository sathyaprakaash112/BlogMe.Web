
using BlogMe.Data;
using BlogMe.Models.Domain;
using BlogMe.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BlogMe.Repository
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BlogMeDbContext blogMeDbContext;

        public BlogPostLikeRepository(BlogMeDbContext blogMeDbContext)
        {
            this.blogMeDbContext = blogMeDbContext;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await blogMeDbContext.BlogPostLike.AddAsync(blogPostLike);

            await blogMeDbContext.SaveChangesAsync();

            return blogPostLike;

        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await blogMeDbContext.BlogPostLike.Where(x=>x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await blogMeDbContext.BlogPostLike.CountAsync(x=>x.BlogPostId == blogPostId);
        }
    }
}
