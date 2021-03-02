﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalicarnassusChat.Models
{
    public class ReplyCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(450, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }
    }
}