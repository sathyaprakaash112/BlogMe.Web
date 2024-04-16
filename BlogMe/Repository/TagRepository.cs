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
            return blogMeDbContext.Tags.CountAsync();
        }

        public async Task<Tag?> DeleteAsync(Guid Id)
        {
            var existingTag = await blogMeDbContext.Tags.FindAsync(Id);

            if (existingTag != null)
            {
                blogMeDbContext.Tags.Remove(existingTag);
                await blogMeDbContext.SaveChangesAsync();
                return existingTag;
            }

            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await blogMeDbContext.Tags.ToListAsync();
        }

        public async Task<Tag?> GetAsync(Guid Id)
        {
            return await blogMeDbContext.Tags.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await blogMeDbContext.Tags.FindAsync(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                await blogMeDbContext.SaveChangesAsync();

                return existingTag;
            }

            return null;
        }
    }
}
