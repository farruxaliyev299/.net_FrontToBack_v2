using Microsoft.AspNetCore.Mvc;
using WebUI_v2.DAL;

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
    }
}
