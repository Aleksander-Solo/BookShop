using BookShop.DataAccesLayer.Entities;
using BookShop.DataAccesLayer.Repository.Interfaces;
using BookShop.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMemoryCache _memoryCache;
        private readonly MapperConfig _mapper;
        private const string memoryTopKey = "myMemoryKey";
        private const string memoryRecommendedKey = "recommendedBooksMemoryKey";

        public BookService(IBookRepository repository, MapperConfig mapper, IMemoryCache memoryCache)
        {
            _repository = repository;
            _mapper = mapper;
            _memoryCache = memoryCache;
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
            IEnumerable<BookViewModel> books;
            int pageSize = 4;
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            if (!_memoryCache.TryGetValue(memoryTopKey, out books))
            {
                books = _mapper.Map(_repository.GetTopBooks());
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));
                _memoryCache.Set(memoryTopKey, books, cacheEntryOptions); 
                return books.Skip(excludeRecords).Take(pageSize).ToList();
            }
            else
            {
                books = _memoryCache.Get<IEnumerable<BookViewModel>>(memoryTopKey).Skip(excludeRecords).Take(pageSize);
                return books.ToList();
            }
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

        public List<BookViewModel> GetRecommendedBooks(string typeOfBook)
        {
            List<BookViewModel> books;
            if (!_memoryCache.TryGetValue(memoryRecommendedKey, out books))
            {
                books = _mapper.Map(_repository.GetRecommendedBooks(typeOfBook));
                var memoryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));
                _memoryCache.Set(memoryRecommendedKey, books, memoryOptions);
            }
            else
            {
                books = _memoryCache.Get<List<BookViewModel>>(memoryRecommendedKey);
            }
            return books; 
        }
    }
}
