using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public interface IBookService
    {
        public List<BookViewModel> GetBooks(int pageNumber);
        public List<BookViewModel> GetRecommendedBooks(string typeOfBook);
        public List<BookViewModel> GetBooks(string phrase);
        public List<BookViewModel> GetTopBooks(int pageNumber);
        public BookViewModel GetBook(int id);
        public BookCardViewModel GetBookToShopCard(int id);
        public void Delete(int id);
        public void Update(int id, BookViewModel book);
        public void Create(BookViewModel book);
        public int GetNumberOfBook();
        public int GetNumberOfTopBook();
    }
}
