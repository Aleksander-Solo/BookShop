﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Tytuł")]
        public string Title { get; set; }
        [DisplayName("Treść")]
        public string Content { get; set; }

        public int AuthorId { get; set; }
        public UserViewModel Author { get; set; }

        public byte Stars { get; set; }

        public int BookId { get; set; }
    }
}
