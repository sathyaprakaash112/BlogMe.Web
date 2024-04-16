using BlogMe.Data;
using BlogMe.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogMe.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogMeDbContext blogMeDbContext;

        public BlogPostRepository(BlogMeDbContext blogMeDbContext)
        {
            this.blogMeDbContext = blogMeDbContext;
        }
        
        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await blogMeDbContext.AddAsync(blogPost);
            await blogMeDbContext.SaveChangesAsync();
            return blogPost;
        }

        public Task<BlogPost> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await blogMeDbContext.BlogPosts.Include(x=> x.Tags).ToListAsync();
        }

        public Task<BlogPost> GetBlogPostAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost> GetByUrlHandleAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
