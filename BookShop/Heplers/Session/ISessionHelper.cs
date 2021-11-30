using BookShop.Models;

namespace BookShop.Heplers
{
    public interface ISessionHelper
    {
        public void AddBook(BookCardViewModel book);
        public void RemoveBook(int id);
        public ShopCardViewModel GetShopCard();
        public void DeleteSession();
    }
}
