using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proyecto04.Areas.Identity.Models;
using Proyecto04.Models;
using System.ComponentModel.DataAnnotations;

namespace Proyecto04.Controllers
{
    public class UsuariosController : Controller
    {
        private UserManager<MiUser> userManager;

        public UsuariosController(UserManager<MiUser> userManager)
        {
            this.userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        [Authorize(Roles = "Admin")]
        public ViewResult Crear() => View();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Crear(UserInput input)
        {
            if (ModelState.IsValid)
            {
                MiUser nuevo = new MiUser
                {
                    UserName = input.Email,
                    Email = input.Email,
                    EmailConfirmed = true                    
                };

                IdentityResult result = await userManager.CreateAsync(nuevo, input.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }

            return View(input);
        }
    }
}
