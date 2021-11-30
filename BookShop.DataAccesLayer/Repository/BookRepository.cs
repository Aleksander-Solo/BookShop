using BookShop.DataAccesLayer.Entities;
using BookShop.DataAccesLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Book book)
        {
            book.DateAdded = DateTime.Now;
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Book book = _context.Books.SingleOrDefault(x => x.Id == id);

            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public Book GetBook(int id)
        {
            Book book = _context.Books.Include(x => x.TypeOfBook)
                                      .Include(x => x.PublishingHause)
                                      .Include(x => x.Cover)
                                      .Include(x => x.Comments).ThenInclude(x => x.Author).SingleOrDefault(x => x.Id == id);

            return book;
        }

        public List<Book> GetBooks(int pageNamber)
        {
            int pageSize = 8;
            int excludeRecords = (pageSize * pageNamber) - pageSize;
            return _context.Books.Skip(excludeRecords).Take(pageSize).Include(x => x.TypeOfBook).OrderBy(x => x.Title).AsNoTracking().ToList();
        }

        public List<Book> GetBooks(string phrase)
        {
            return _context.Books.Where(x => x.Title.Contains(phrase)).Include(x => x.TypeOfBook).AsNoTracking().ToList();
        }

        public int GetNumberOfBook()
        {
            return _context.Books.Count();
        }

        public int GetNumberOfTopBook()
        {
            return _context.Books.Where(x => x.OnTop == true).Count();
        }

        public List<Book> GetTopBooks(int pageNamber)
        {
            int pageSize = 4;
            int excludeRecords = (pageSize * pageNamber) - pageSize;
            return _context.Books.Where(x => x.OnTop == true).Skip(excludeRecords).Take(pageSize)
                                 .Include(x => x.TypeOfBook).AsNoTracking().ToList();
        }

        public void Update(int id, Book book)
        {
            Book book1 = _context.Books.FirstOrDefault(x => x.Id == id);

            book1.NumperOfPages = book.NumperOfPages;
            book1.OnTop = book.OnTop;
            book1.Price = book.Price;
            book1.PublishingHauseId = book.PublishingHauseId;
            book1.ReleaseDate = book.ReleaseDate;
            book1.Title = book.Title;
            book1.TypeOfBookId = book.TypeOfBookId;
            book1.Description = book.Description;
            book1.CoverId = book.CoverId;
            book1.Author = book.Author;

            if (book.Picture is not null || book.Picture.Any())
                book1.Picture = book.Picture;

            _context.SaveChanges();
        }
    }
}
