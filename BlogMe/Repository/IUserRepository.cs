using Microsoft.AspNetCore.Identity;

namespace BlogMe.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();

    }
}
