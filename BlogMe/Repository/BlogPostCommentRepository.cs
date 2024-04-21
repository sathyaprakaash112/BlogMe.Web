using BlogMe.Data;
using BlogMe.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogMe.Repository
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BlogMeDbContext blogMeDbContext;

        public BlogPostCommentRepository(BlogMeDbContext blogMeDbContext)
        {
            this.blogMeDbContext = blogMeDbContext;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment comment)
        {
            await blogMeDbContext.BlogPostComment.AddAsync(comment); 
            await blogMeDbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetByBlogIdAsync(Guid blogPostId)
        {
            return  await blogMeDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId).ToListAsync();

        }
    }
}
