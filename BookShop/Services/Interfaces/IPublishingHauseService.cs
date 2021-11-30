using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public interface IPublishingHauseService
    {
        public void Create(PublishingHauseViewModel hause);
        public void Delate(int id);
        public List<PublishingHauseViewModel> GetHauses();
    }
}
