using BookShop.DataAccesLayer.Repository.Interfaces;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly MapperConfig _mapper;

        public AccountService(IAccountRepository repository, MapperConfig mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void AddUser(RegisterUserViewModel user) => _repository.AddUser(_mapper.Map(user));

        public UserViewModel GetUser(string email) => _mapper.Map_Author(_repository.GetUser(email));

        public UserViewModel GetUser(int id) => _mapper.Map_Author(_repository.GetUser(id));

        public List<UserViewModel> GetUsers(string fraza) => _mapper.Map(_repository.GetUsers(fraza));

        public UpdateUserViewModel GetUserToUpdate(string email) => _mapper.Map(_repository.GetUser(email));

        public void GiveRole(int id) => _repository.GiveRole(id);

        public UpdateUserViewModel Login(string email, string password) => _mapper.Map(_repository.Login(email, password));

        public void TakeRole(int id) => _repository.TakeRole(id);

        public void UpdateUser(UpdateUserViewModel user) => _repository.UpdateUser(_mapper.Map(user));
    }
}
