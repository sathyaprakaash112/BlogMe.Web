using BlogMe.Models.Domain;

namespace BlogMe.Repository
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllAsync();

        Task<Tag> GetAsync(Guid Id);

        Task<Tag> AddAsync(Tag tag);

        Task<Tag> UpdateAsync(Tag tag);
        Task<Tag> DeleteAsync(Guid Id);
        Task<int> CountAsync();
    }
}
