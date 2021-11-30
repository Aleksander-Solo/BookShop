using BookShop.DataAccesLayer.Entities;
using BookShop.DataAccesLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Repository
{
    public class PublishingHauseRepository : IPublishingHauseRepository
    {
        private readonly ApplicationDbContext _context;

        public PublishingHauseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(PublishingHause hause)
        {
            _context.PublishingHauses.Add(hause);
            _context.SaveChanges();
        }

        public void Delate(int id)
        {
            throw new NotImplementedException();
        }

        public List<PublishingHause> GetHauses()
        {
            return _context.PublishingHauses.ToList();
        }
    }
}
