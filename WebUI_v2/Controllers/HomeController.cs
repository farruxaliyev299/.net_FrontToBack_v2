using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebUI_v2.DAL;
using WebUI_v2.ViewModels;

namespace WebUI_v2.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders = _context.Sliders.ToList(),
                Summary = _context.Summary.FirstOrDefault(),
                Categories = _context.Categories.Where(ctg=>!ctg.isDeleted).ToList(),
                Products = _context.Products.Where(prod=>!prod.isDeleted).Include(product => product.Images).ToList(),
                ProductImages = _context.ProductImages.ToList(),
            };
            return View(homeVM);
        }
    }
}
