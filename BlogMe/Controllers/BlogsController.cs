using BlogMe.Data;
using BlogMe.Models.Domain;
using BlogMe.Models.ViewModels;
using BlogMe.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogMe.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IBlogPostLikeRepository blogPostLikeRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBlogPostCommentRepository blogPostCommentRepository;

        public BlogsController(IBlogPostRepository blogPostRepository,IBlogPostLikeRepository blogPostLikeRepository,
            SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager,
            IBlogPostCommentRepository blogPostCommentRepository)   
        {
            this.blogPostRepository = blogPostRepository;
            this.blogPostLikeRepository = blogPostLikeRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.blogPostCommentRepository = blogPostCommentRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
            var liked = false;

            var blogPost = await blogPostRepository.GetByUrlHandleAsync(urlHandle);
            var blogDetailsViewModel = new BlogDetailsViewModel();


            if (blogPost != null)
            {
                var totalLikes = await blogPostLikeRepository.GetTotalLikes(blogPost.Id);

                if (signInManager.IsSignedIn(User))
                {
                    var likesForBlog = await blogPostLikeRepository.GetLikesForBlog(blogPost.Id);

                    var userId = userManager.GetUserId(User);

                    if(userId != null)
                    {
                        var likeFromUser = likesForBlog.FirstOrDefault(x => x.UserId == Guid.Parse(userId));
                        if(likeFromUser != null)
                        {
                            liked = true;
                        }
                    }
                }

                var blogComments = await blogPostCommentRepository.GetByBlogIdAsync(blogPost.Id);

                var blogCommentsForView = new List<BlogComment>();

                foreach(var blogComment in blogComments)
                {
                    blogCommentsForView.Add(new BlogComment
                    {
                        DateAdded = blogComment.DateAdded,
                        Description = blogComment.Description,
                        Username = (await userManager.FindByIdAsync(blogComment.UserId.ToString())).UserName
                    });
                }

                blogDetailsViewModel = new BlogDetailsViewModel
                {
                    Id = blogPost.Id,
                    Author = blogPost.Author,
                    Content = blogPost.Content,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    Heading = blogPost.Heading,
                    PageTitle = blogPost.PageTitle,
                    PublishedDate = blogPost.PublishedDate,
                    ShortDescription = blogPost.ShortDescription,
                    Tags = blogPost.Tags,
                    UrlHandle = blogPost.UrlHandle,
                    Visible = blogPost.Visible,
                    TotalLikes = totalLikes,
                    Liked = liked,
                    Comments = blogCommentsForView
                };
            }

            return View(blogDetailsViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(BlogDetailsViewModel blogDetailsViewModel)
        {
            if (signInManager.IsSignedIn(User))
            {
                var model = new BlogPostComment
                {
                    BlogPostId = blogDetailsViewModel.Id,
                    UserId = Guid.Parse(userManager.GetUserId(User)),
                    Description = blogDetailsViewModel.CommentDescription,
                    DateAdded = DateTime.Now,

                };
                await blogPostCommentRepository.AddAsync(model);
                return RedirectToAction("Index","Home",new {urlHandle = blogDetailsViewModel.UrlHandle});
            }

            return Forbid();
            
        }
    }
}
