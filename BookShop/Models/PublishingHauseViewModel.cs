using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class PublishingHauseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public byte[] Logo { get; set; }

        public ICollection<BookViewModel> Books { get; set; }
    }
}
