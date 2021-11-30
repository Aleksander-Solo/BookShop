using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public byte[] Picture { get; set; }

        public string Role { get; set; }
        [DisplayName("Historia zakupów:")]
        public List<PurchaseHistoryViewModel> PurchasesHistorie { get; set; }
    }
}
