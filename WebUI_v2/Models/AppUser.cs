using Microsoft.AspNetCore.Identity;

namespace WebUI_v2.Models
{
    public class AppUser:IdentityUser
    {
        public bool isActivated { get; set; }
    }
}
