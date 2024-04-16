using BlogMe.Models.Domain;

namespace BlogMe.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Tag> Tags { get; set; }

        public IEnumerable<BlogPost> BlogPosts { get; set; }
    }
}
