using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC6.Models
{
    public class User
    {
        /// <summary>
        /// User Number
        /// </summary>
        [Key] //PK setup
        public int UserNo { get; set; }

        [Required(ErrorMessage = "Please input user name")] //Not Null
        public string UserName { get; set; }

        [Required] //Not Null
        public string UserId { get; set; }

        [Required] //Not Null
        public string UserPassword { get; set; }
    }
}
