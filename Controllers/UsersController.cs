using EarthquakeHorses4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Controllers
{
    [Authorize(Roles = "Gerant, Secretaire")]
    public class UsersController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        private readonly IPasswordHasher<User> passwordHasher;

        public UsersController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IPasswordHasher<User> passwordHasher)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
        }

        public IActionResult Index()
        {
            var users = userManager.Users;
            return View(users);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Nom, string Prenom, string Email, string Description, string Role)
        {
            if (await userManager.FindByNameAsync(Email) == null)
            {
                User user = new User()
                {
                    UserName = Email,
                    Nom = Nom,
                    Prenom = Prenom,
                    Email = Email,
                    Description = Description
                };

                IdentityResult result = await userManager.CreateAsync(user, "Azertyuiop-1");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Role);
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            
            if (user == null)
            {
                return NotFound();
            }

            var model = new UserEdit
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Nom = user.Nom,
                Prenom = user.Prenom,
                Description = user.Description
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEdit model)
        {

            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return NotFound();
            } else
            {
                user.UserName = model.UserName;
                user.Nom = model.Nom;
                user.Prenom = model.Prenom;
                user.Email = model.Email;
                user.Description = model.Description;

                IdentityResult result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Chevals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            await userManager.DeleteAsync(user);

            return RedirectToAction(nameof(Index));
        }
    }
}
