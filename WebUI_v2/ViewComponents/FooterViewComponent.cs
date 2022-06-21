using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebUI_v2.DAL;

namespace WebUI_v2.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private AppDbContext _context { get; }
        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Settings.ToDictionaryAsync(setting => setting.Key, setting => setting.Value));
        }
    }
}
