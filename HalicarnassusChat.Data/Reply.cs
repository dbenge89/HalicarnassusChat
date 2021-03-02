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
        int ReplyId { get; set; }
        [Required]
        string Text { get; set; }
        [Required]
        Guid Author { get; set; }
        [Required]
        public int Id { get; set; }
        [ForeignKey(nameof(CommentId))]
        public virtual Comment Comment { get; set; }
    }
}
