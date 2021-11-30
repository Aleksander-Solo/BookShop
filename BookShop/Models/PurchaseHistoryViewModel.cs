using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class PurchaseHistoryViewModel
    {
        public int Id { get; set; }
        [DisplayName("Imię")]
        public string FirstName { get; set; }
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }

        public int BuyerId { get; set; }

        public DateTime DateOfPurchase { get; set; }
        [DisplayName("Adres")]
        public string Adress { get; set; }

        public ICollection<BookCardViewModel> Books { get; set; }

        public double ToPay { get; set; }
    }
}
