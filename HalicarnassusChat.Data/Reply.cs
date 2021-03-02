using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalicarnassusChat.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public Guid Author { get; set; }

        [Required]
        public int CommentId { get; set; }

        [ForeignKey(nameof(CommentId))]
        public virtual Comment Comment { get; set; }
    }
}
