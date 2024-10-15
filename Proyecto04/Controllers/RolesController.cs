using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto04.Controllers
{
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        public RolesController(RoleManager<IdentityRole> roleMgr)
        {
            roleManager = roleMgr;
        }

        public ViewResult Index() => View(roleManager.Roles);

        public IActionResult Crear() => View();

        [HttpPost]
        public async Task<IActionResult> Crear(string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
