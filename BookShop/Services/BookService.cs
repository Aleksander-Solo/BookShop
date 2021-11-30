using BookShop.DataAccesLayer.Entities;
using BookShop.DataAccesLayer.Repository.Interfaces;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly MapperConfig _mapper;

        public BookService(IBookRepository repository, MapperConfig mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(BookViewModel book) => _repository.Create(_mapper.Map(book));

        public void Delete(int id) => _repository.Delete(id);

        public BookViewModel GetBook(int id) => _mapper.Map(_repository.GetBook(id));

        public BookCardViewModel GetBookToShopCard(int id) => _mapper.Map_Card(_repository.GetBook(id));

        public List<BookViewModel> GetBooks(int pageNumber)
        {
            return _mapper.Map(_repository.GetBooks(pageNumber));
        }

        public int GetNumberOfBook()
        {
            return _repository.GetNumberOfBook();
        }

        public List<BookViewModel> GetTopBooks(int pageNumber)
        {
            return _mapper.Map(_repository.GetTopBooks(pageNumber));
        }

        public void Update(int id, BookViewModel book)
        {
            _repository.Update(id, _mapper.Map(book));
        }

        public List<BookViewModel> GetBooks(string phrase)
        {
            return _mapper.Map(_repository.GetBooks(phrase));
        }

        public int GetNumberOfTopBook()
        {
            return _repository.GetNumberOfTopBook();
        }
    }
}
