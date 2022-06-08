using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI_v2.DAL;
using WebUI_v2.Models;
using WebUI_v2.ViewModels.Categories;

namespace WebUI_v2.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private AppDbContext _context { get; }
        public static IEnumerable<Category> categories { get; set; }

        public CategoryController(AppDbContext context)
        {
            _context = context;
            categories = _context.Categories.Where(ctg => !ctg.isDeleted);
        }
        public IActionResult Index()
        {
            return View(_context.Categories.Where(category => !category.isDeleted));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CategoryAddVM category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = false;
            foreach (var ctg in categories)
            {
                if(ctg.Name.ToLower() == category.Name.ToLower())
                {
                    isExist = true;
                    break;
                }
            }
            if (isExist)
            {
                ModelState.AddModelError("Name", $"{category.Name} is already exist");
                return View();
            }
            Category newCategory = new Category
            {
                Name = category.Name
            };
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
