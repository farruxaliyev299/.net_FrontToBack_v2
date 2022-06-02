using System.Collections.Generic;

namespace WebUI_v2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public int Discount { get; set; }
        public bool isDeleted { get; set; }
        public List<ProductImage> Images { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
