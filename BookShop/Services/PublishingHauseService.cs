using BookShop.DataAccesLayer.Repository.Interfaces;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class PublishingHauseService : IPublishingHauseService
    {
        private readonly MapperConfig _mapper;
        private readonly IPublishingHauseRepository _repository;

        public PublishingHauseService(MapperConfig mapper, IPublishingHauseRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Create(PublishingHauseViewModel hause) => _repository.Create(_mapper.Map(hause));

        public void Delate(int id) => _repository.Delate(id);

        public List<PublishingHauseViewModel> GetHauses() => _mapper.Map(_repository.GetHauses());
    }
}
