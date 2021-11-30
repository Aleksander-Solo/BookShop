using BookShop.DataAccesLayer.Entities;
using BookShop.DataAccesLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Repository
{
    public class CoverAndTypeRepository : ICoverAndTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public CoverAndTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddCover(Cover cover)
        {
            _context.Covers.Add(cover);
            _context.SaveChanges();
        }

        public void AddType(TypeOfBook type)
        {
            _context.TypesOfBook.Add(type);
            _context.SaveChanges();
        }

        public void DelateCover(int id)
        {
            throw new NotImplementedException();
        }

        public void DelateType(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cover> GetCovers()
        {
            return _context.Covers.ToList();
        }

        public List<TypeOfBook> GetTypes()
        {
            return _context.TypesOfBook.ToList();
        }
    }
}
