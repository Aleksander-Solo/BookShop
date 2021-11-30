using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Entities
{
    public class PurchaseHistory
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("BuyerId")]
        public int BuyerId { get; set; }
        public User Buyer { get; set; }

        public DateTime DateOfPurchase { get; set; }
        public string Adress { get; set; }

        public ICollection<Book> Books { get; set; }

        public double ToPay { get; set; }
    }
}
