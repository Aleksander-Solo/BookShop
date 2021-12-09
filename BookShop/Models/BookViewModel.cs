using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        [MaxLength(45)]
        [DisplayName("Tytuł")]
        public string Title { get; set; }
        [MaxLength(50)]
        [DisplayName("Autor")]
        public string Author { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Data wydania")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Liczba stron")]
        public int NumperOfPages { get; set; }

        [DisplayName("Cena")]
        public double Price { get; set; }

        public bool OnTop { get; set; }

        public byte[] Picture { get; set; }

        public int CoverId { get; set; }
        [DisplayName("Okładka")]
        public string Cover { get; set; }

        public int TypeOfBookId { get; set; }
        [DisplayName("Gatunek")]
        public string TypeOfBook { get; set; }

        public int PublishingHauseId { get; set; }
        [DisplayName("Wydawnictwo")]
        public string PublishingHause { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }
    }
}
