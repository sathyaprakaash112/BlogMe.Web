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

        public async Task<BlogPost?> DeleteAsync(Guid Id)
        {
            var existingBlog = await blogMeDbContext.BlogPosts.FindAsync(Id);

            if (existingBlog != null)
            {
                blogMeDbContext.BlogPosts.Remove(existingBlog);
                await blogMeDbContext.SaveChangesAsync();
                return existingBlog;
            }

            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await blogMeDbContext.BlogPosts.Include(x=> x.Tags).ToListAsync();
        }

        public async Task<BlogPost> GetBlogPostAsync(Guid Id)
        {
            return await blogMeDbContext.BlogPosts.Include(x=>x.Tags).FirstOrDefaultAsync(x=>x.Id == Id);
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
            return await blogMeDbContext.BlogPosts.Include(x => x.Tags)
                            .FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var existingBlog = await blogMeDbContext.BlogPosts.Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if(existingBlog != null)
            {
                existingBlog.Id = blogPost.Id;
                existingBlog.Heading = blogPost.Heading;
                existingBlog.PageTitle = blogPost.PageTitle;
                existingBlog.Content = blogPost.Content;
                existingBlog.ShortDescription = blogPost.ShortDescription;
                existingBlog.Author = blogPost.Author;
                existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlog.UrlHandle = blogPost.UrlHandle;
                existingBlog.Visible = blogPost.Visible;
                existingBlog.PublishedDate = blogPost.PublishedDate;
                existingBlog.Tags = blogPost.Tags;

                await blogMeDbContext.SaveChangesAsync();
                return existingBlog;
            }

            return null;
        }
    }
}
