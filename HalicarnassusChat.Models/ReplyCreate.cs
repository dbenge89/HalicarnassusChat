using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace HalicarnassusChat.Models
{
    public class ReplyCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(450, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }
        [Required]
        public string CommentId { get; set; }
      
        [Required]
        public Guid Author { get; set; }

        public List<SelectListItem> Comments { get; set; }
    }
}
