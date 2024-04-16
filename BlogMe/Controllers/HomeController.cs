using BlogMe.Models;
using BlogMe.Models.ViewModels;
using BlogMe.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITagRepository tagRepository;
        private readonly IBlogPostRepository blogPostRepository;

        public HomeController(ILogger<HomeController> logger, ITagRepository tagRepository, IBlogPostRepository blogPostRepository)
        {
            _logger = logger;
            this.tagRepository = tagRepository;
            this.blogPostRepository = blogPostRepository;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await tagRepository.GetAllAsync();
            var blogPosts = await blogPostRepository.GetAllAsync();

            var model = new HomeViewModel
            {
                BlogPosts = blogPosts,
                Tags = tags
            };
            return View(model);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
