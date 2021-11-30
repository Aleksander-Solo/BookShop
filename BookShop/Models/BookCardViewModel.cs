using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class BookCardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumperOfPages { get; set; }

        public double Price { get; set; }

        public bool OnTop { get; set; }

        public byte[] Picture { get; set; }

        public int CoverId { get; set; }

        public int TypeOfBookId { get; set; }

        public int PublishingHauseId { get; set; }
    }
}
