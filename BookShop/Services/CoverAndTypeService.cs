using BookShop.DataAccesLayer.Repository.Interfaces;
using BookShop.Models;
using BookShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class CoverAndTypeService : ICoverAndTypeService
    {
        private readonly MapperConfig _mapper;
        private readonly ICoverAndTypeRepository _repository;

        public CoverAndTypeService(MapperConfig mapper, ICoverAndTypeRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void AddCover(CoverViewModel cover) => _repository.AddCover(_mapper.Map(cover));

        public void AddType(TypeOfBookViewModel type) => _repository.AddType(_mapper.Map(type));

        public void DelateCover(int id) => _repository.DelateCover(id);

        public void DelateType(int id) => _repository.DelateType(id);

        public List<CoverViewModel> GetCovers() => _mapper.Map(_repository.GetCovers());

        public List<TypeOfBookViewModel> GetTypes() => _mapper.Map(_repository.GetTypes());
    }
}
