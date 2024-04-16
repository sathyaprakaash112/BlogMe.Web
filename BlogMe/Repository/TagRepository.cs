using BlogMe.Data;
using BlogMe.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogMe.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogMeDbContext blogMeDbContext;

        public TagRepository(BlogMeDbContext blogMeDbContext)
        {
            this.blogMeDbContext = blogMeDbContext;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            await blogMeDbContext.Tags.AddAsync(tag);
            await blogMeDbContext.SaveChangesAsync();
            return tag;
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Tag> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await blogMeDbContext.Tags.ToListAsync();
        }

        public async Task<Tag> GetAsync(Guid Id)
        {
            return await blogMeDbContext.Tags.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public Task<Tag> UpdateAsync(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
