using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalicarnassusChat.Data
{
    public class Comment
    {
        [Key]
        int Id { get; set; }

        [Required]
        string Text { get; set; }

        [Required]
        Guid Author { get; set; }

        public virtual List<Reply> Replies { get; set; }

        [Required]
        public int PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; }

    }
}
