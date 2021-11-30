using BookShop.DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Repository.Interfaces
{
    public interface IPublishingHauseRepository
    {
        public void Create(PublishingHause hause);
        public void Delate(int id);
        public List<PublishingHause> GetHauses();
    }
}
