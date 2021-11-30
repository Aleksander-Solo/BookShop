using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }

        public byte Stars { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
