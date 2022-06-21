using System.ComponentModel.DataAnnotations;

namespace WebUI_v2.ViewModels.Account
{
    public class LoginVM
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public bool isPersistent { get; set; }
    }
}
