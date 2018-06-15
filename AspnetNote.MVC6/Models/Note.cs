using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetNote.MVC6.Models
{
    public class Note
    {
        /// <summary>
        /// Note number
        /// </summary>
        [Key]
        public int NoteNo { get; set; }

        [Required(ErrorMessage = "Please input Title")] //Not Null
        public string NoteTitle { get; set; }

        [Required(ErrorMessage = "Please input contents")] //Not Null
        public string NoteContents { get; set; }

        [Required]
        public int UserNo { get; set; }

        [ForeignKey("UserNo")]
        public virtual User User { get; set; }
    }
}
