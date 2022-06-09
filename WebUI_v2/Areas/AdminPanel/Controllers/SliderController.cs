using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using WebUI_v2.DAL;
using WebUI_v2.Models;
using WebUI_v2.Utilities;

namespace WebUI_v2.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private AppDbContext _context { get; }
        private IWebHostEnvironment _env{ get; }

        public SliderController(AppDbContext context , IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
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

        public async Task<IActionResult> Add(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if(!slider.Photo.CheckFileSize(800))
            {
                ModelState.AddModelError("Photo", "Maximum file size is 200 Kb!");
                return View();
            }
            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File type must be image");
                return View();
            }
            var fileName = Guid.NewGuid().ToString() + slider.Photo.FileName;
            var resultPath = Path.Combine(_env.WebRootPath, "img", fileName);
            using (FileStream fileStream = new FileStream(resultPath , FileMode.Create))
            {
                slider.Photo.CopyTo(fileStream);
            }
            slider.Url = await slider.Photo.SaveFileAsync(_env.WebRootPath, "img");
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var slider = _context.Sliders.Find(id);
            if(slider == null)
            {
                return NotFound();
            }
            var removePath = Utility.GetPath(_env.WebRootPath, "img", slider.Url);
            if (System.IO.File.Exists(removePath))
            {
                System.IO.File.Delete(removePath);
            }
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
