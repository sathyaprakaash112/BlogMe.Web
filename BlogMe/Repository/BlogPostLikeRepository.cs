
using BlogMe.Data;
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
        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await blogMeDbContext.BlogPostLike.CountAsync(x=>x.BlogPostId == blogPostId);
        }
    }
}
