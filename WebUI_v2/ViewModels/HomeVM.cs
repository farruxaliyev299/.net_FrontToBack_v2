using System.Collections.Generic;
using WebUI_v2.Models;

namespace WebUI_v2.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }

        public Summary Summary { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
