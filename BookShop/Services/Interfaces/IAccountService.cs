using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public interface IAccountService
    {
        public UpdateUserViewModel Login(string email, string password);
        public void AddUser(RegisterUserViewModel user);
        public void UpdateUser(UpdateUserViewModel user);
        public UserViewModel GetUser(string email);
        public UserViewModel GetUser(int id);
        public UpdateUserViewModel GetUserToUpdate(string email);
        public List<UserViewModel> GetUsers(string fraza);
        public void GiveRole(int id);
        public void TakeRole(int id);
    }
}
