using BookShop.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Heplers
{
    public class SessionHelper : ISessionHelper
    {
        private IHttpContextAccessor _httpAccessor;

        public SessionHelper(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }

        private const string SesionKey = "shopCard";

        public void AddBook(BookCardViewModel book)
        {
            List<BookCardViewModel> list;
            if (_httpAccessor.HttpContext.Session.GetString(SesionKey) is null)
                list = new List<BookCardViewModel>();
            else
                list = JsonConvert.DeserializeObject<List<BookCardViewModel>>(_httpAccessor.HttpContext.Session.GetString(SesionKey));

            list.Add(book);
            _httpAccessor.HttpContext.Session.SetString(SesionKey, JsonConvert.SerializeObject(list));
        }

        public void RemoveBook(int id)
        {
            if (_httpAccessor.HttpContext.Session.GetString(SesionKey) is not null)
            {
                List<BookCardViewModel> list = JsonConvert.DeserializeObject<List<BookCardViewModel>>(_httpAccessor.HttpContext.Session.GetString(SesionKey));
                BookCardViewModel book = list.FirstOrDefault(x => x.Id == id);
                if (book is not null)
                    list.Remove(book);
                _httpAccessor.HttpContext.Session.SetString(SesionKey, JsonConvert.SerializeObject(list));
            }
        }

        public ShopCardViewModel GetShopCard()
        {
            List<BookCardViewModel> list;
            double price = 0;
            if (_httpAccessor.HttpContext.Session.GetString(SesionKey) is not null)
            {
                list = JsonConvert.DeserializeObject<List<BookCardViewModel>>(_httpAccessor.HttpContext.Session.GetString(SesionKey));

                foreach (BookCardViewModel book in list)
                {
                    price += book.Price;
                }
            }
            else
            {
                list = new List<BookCardViewModel>();
            }

            ShopCardViewModel shopCard = new ShopCardViewModel
            {
                Books = list,
                Price = price,
                Count = list.Count()
            };

            return shopCard;
        }

        public void DeleteSession()
        {
            _httpAccessor.HttpContext.Session.Remove(SesionKey);
        }
    }
}
