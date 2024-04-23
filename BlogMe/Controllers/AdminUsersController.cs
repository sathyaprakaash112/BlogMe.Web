using BlogMe.Models.ViewModels;
using BlogMe.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogMe.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : Controller
    {
        private IUserRepository userRepository;
        private readonly UserManager<IdentityUser> userManager;

        public AdminUsersController(IUserRepository userRepository, UserManager<IdentityUser> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await userRepository.GetAll();

            var userViewModel = new UserViewModel();

            userViewModel.Users = new List<User>();

            foreach(var user in users)
            {
                userViewModel.Users.Add(new User
                {
                    Id = Guid.Parse(user.Id),
                    Username = user.UserName,
                    EmailAddress = user.Email
                });
            }

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> List(UserViewModel userViewModel) 
        {
            var identityUser = new IdentityUser
            {
                UserName = userViewModel.Username,
                Email = userViewModel.Email,
            };

            var identityResult = await userManager.CreateAsync(identityUser,userViewModel.Password);

            if(identityResult != null)
            {
                if(identityResult.Succeeded)
                {
                    //assign user

                    var roles = new List<string> { "User" };

                    if (userViewModel.AdminRoleCheckbox)
                    {
                        roles.Add("Admin");
                    }

                    identityResult = await userManager.AddToRolesAsync(identityUser, roles);

                    if(identityResult != null && identityResult.Succeeded)
                    {
                        return RedirectToAction("List", "AdminUsers");
                    }

                    
                }                
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var deletedUser = await userManager.FindByIdAsync(Id.ToString());

            if(deletedUser != null)
            {
                var identityResult = await userManager.DeleteAsync(deletedUser);
                if(identityResult != null && identityResult.Succeeded)
                {
                    return RedirectToAction("List", "AdminUsers");
                }
                return View();
            }
            return Problem("Some problem occured.");
        }
    }
}
