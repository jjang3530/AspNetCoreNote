using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC6.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="User Id required from View Model")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "User PW required from View Model")]
        public string UserPassword { get; set; }
    }
}
