using System.Collections.Generic;

namespace BookShop.Models
{
    public class ShopCardViewModel
    {
        public List<BookCardViewModel> Books { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
    }
}
