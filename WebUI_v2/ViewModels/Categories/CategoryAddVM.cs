using System.ComponentModel.DataAnnotations;

namespace WebUI_v2.ViewModels.Categories
{
    public class CategoryAddVM
    {
        [Required]
        public string Name { get; set; }
    }
}
