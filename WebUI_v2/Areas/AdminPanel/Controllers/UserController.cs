using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebUI_v2.Models;

namespace WebUI_v2.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class UserController : Controller
    {
        private UserManager<AppUser> _userManager { get; }

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public async Task<IActionResult> Deactivate(string id)
        {
            AppUser userDb = await _userManager.FindByNameAsync(id);
            userDb.isActivated = false;
            await _userManager.UpdateAsync(userDb);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Activate(string id)
        {
            AppUser userDb = await _userManager.FindByNameAsync(id);
            userDb.isActivated = true;
            await _userManager.UpdateAsync(userDb);
            return RedirectToAction("Index");
        }


    }
}
