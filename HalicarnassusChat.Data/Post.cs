using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalicarnassusChat.Data
{
    public class Post
    {
        [Key]
        int Id { get; set; }

        [Required]
        string Title { get; set; }

        [Required]
        string Text { get; set; }

        public virtual List<Comment> Comments { get; set; }

        [Required]
        Guid Author { get; set; }
    }
}
