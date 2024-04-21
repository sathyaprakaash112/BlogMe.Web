using BlogMe.Models.Domain;
using BlogMe.Models.ViewModels;

namespace BlogMe.Repository
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikes(Guid blogPostId);

        Task<BlogPostLike> AddLikeForBlog(BlogPostLike addBlogPostLike);

        Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId);
    }
}
