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
    public class PurchaseHistoryRepository : IPurchaseHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(PurchaseHistory purchase)
        {
            purchase.DateOfPurchase = DateTime.Now;
            List<Book> books = new List<Book>();
            foreach(Book book in purchase.Books)
            {
                books.Add(_context.Books.FirstOrDefault(x => x.Id == book.Id));
            }
            purchase.Books = books;
            _context.PurchaseHistory.Add(purchase);
            _context.SaveChanges();
        }

        public List<PurchaseHistory> Get()
        {
            return _context.PurchaseHistory.Include(x => x.Buyer).Include(x => x.Books).ToList();
        }
    }
}
