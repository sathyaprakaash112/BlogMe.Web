using BlogMe.Models.Domain;

namespace BlogMe.Repository
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment comment);

        Task<IEnumerable<BlogPostComment>> GetByBlogIdAsync(Guid blogPostId);

    }
}
