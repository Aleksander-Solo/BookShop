using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumperOfPages { get; set; }

        public double Price { get; set; }

        public bool OnTop { get; set; }

        public byte[] Picture { get; set; }

        [ForeignKey("CoverId")]
        public int CoverId { get; set; }
        public virtual Cover Cover { get; set; }

        [ForeignKey("TypeOfBookId")]
        public int TypeOfBookId { get; set; }
        public virtual TypeOfBook TypeOfBook { get; set; }

        [ForeignKey("PublishingHauseId")]
        public int PublishingHauseId { get; set; }
        public virtual PublishingHause PublishingHause { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<PurchaseHistory> PurchasesHistorie { get; set; }
    }
}
