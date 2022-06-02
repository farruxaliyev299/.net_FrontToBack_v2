using System.Collections.Generic;
using System.Linq;

namespace WebUI_v2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; }
        public List<Product> Products { get; set; }
    }
}
