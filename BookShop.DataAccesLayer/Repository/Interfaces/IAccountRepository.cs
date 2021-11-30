using BookShop.DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Repository.Interfaces
{
    public interface IAccountRepository
    {
        public User Login(string email, string password);
        public void AddUser(User user);
        public void UpdateUser(User user);
        public User GetUser(string email);
        public User GetUser(int id);
        public List<User> GetUsers(string fraza);
        public void GiveRole(int id);
        public void TakeRole(int id);
    }
}
