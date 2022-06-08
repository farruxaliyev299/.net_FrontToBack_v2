using Microsoft.AspNetCore.Mvc;
using WebUI_v2.DAL;
using WebUI_v2.Models;

namespace WebUI_v2.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private AppDbContext _context { get; }

        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Add(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if(slider.Photo.Length/1024 > 200)
            {
                ModelState.AddModelError("Photo", "Maximum file size is 200 Kb!");
                return View();
            }
            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Photo", "File type must be image");
                return View();
            }
            return Content("Ok bitch!xD");
        }
    }
}
