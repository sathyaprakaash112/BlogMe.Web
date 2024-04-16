using BlogMe.Models.Domain;

namespace BlogMe.Repository
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();

        Task<BlogPost> GetBlogPostAsync(Guid Id);

        Task<BlogPost> GetByUrlHandleAsync(Guid Id);

        Task<BlogPost> AddAsync(BlogPost blogPost);

        Task<BlogPost> UpdateAsync(BlogPost blogPost);
        Task<BlogPost> DeleteAsync(Guid Id);
    }
}
