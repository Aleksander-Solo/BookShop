using BookShop.DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Repository.Interfaces
{
    public interface IBookRepository
    {
        public List<Book> GetBooks(int pageNamber);
        public List<Book> GetRecommendedBooks(string typeOfBook);
        public List<Book> GetBooks(string phrase);
        public IEnumerable<Book> GetTopBooks();
        public Book GetBook(int id);
        public void Delete(int id);
        public void Update(int id, Book book);
        public void Create(Book book);
        public int GetNumberOfBook();
        public int GetNumberOfTopBook();
    }
}
