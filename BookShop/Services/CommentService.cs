using BookShop.DataAccesLayer.Repository.Interfaces;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _repository;
        private MapperConfig _mapper;

        public CommentService(ICommentRepository repository, MapperConfig mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddComment(CommentViewModel comment) => _repository.AddComment(_mapper.Map(comment));

        public void DeleteComment(int id) => _repository.DeleteComment(id);
    }
}
