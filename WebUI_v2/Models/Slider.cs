using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI_v2.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Url { get; set; }

        [NotMapped,Required(ErrorMessage ="Slider field can't been added empty")]
        public IFormFile Photo { get; set; }
    }
}
