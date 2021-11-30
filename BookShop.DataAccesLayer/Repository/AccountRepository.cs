using BookShop.DataAccesLayer.Entities;
using BookShop.DataAccesLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountRepository(ApplicationDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public void AddUser(User user)
        {
            user.HashPassword = _passwordHasher.HashPassword(user, user.HashPassword);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(string email)
        {
            User user = _context.Users.Include(x => x.Role)
                                      .Include(x => x.PurchasesHistorie)
                                      .ThenInclude(x => x.Books).SingleOrDefault(x => x.Email == email);
            return user;
        }

        public User GetUser(int id)
        {
            User user = _context.Users.Include(x => x.Role)
                                      .Include(x => x.PurchasesHistorie)
                                      .ThenInclude(x => x.Books).SingleOrDefault(x => x.Id == id);
            return user;
        }

        public List<User> GetUsers(string fraza)
        {
            if (!String.IsNullOrEmpty(fraza))
            {
                return _context.Users.Include(x => x.Role).Where(x => x.Role.Name != "SuperAdmin")
                                                          .Where(x => x.Name.Contains(fraza) || x.Email.Contains(fraza)).ToList();
            }
            else
            {
                return _context.Users.Include(x => x.Role).Where(x => x.Role.Name != "SuperAdmin").ToList();
            }
            
        }

        public void GiveRole(int id)
        {
            User user = _context.Users.SingleOrDefault(x => x.Id == id);
            int roleId = _context.Roles.FirstOrDefault(x => x.Name == "Admin").Id;
            user.RoleId = roleId;
            _context.SaveChanges();
        }

        public User Login(string email, string password)
        {
            User user = _context.Users.Include(x => x.Role).SingleOrDefault(x => x.Email == email);

            if (user is null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.HashPassword, password);

            if (result == PasswordVerificationResult.Failed)
                return null;

            return user;
        }

        public void TakeRole(int id)
        {
            User user = _context.Users.SingleOrDefault(x => x.Id == id);
            int roleId = _context.Roles.FirstOrDefault(x => x.Name == "User").Id;
            user.RoleId = roleId;
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            User oldUser = _context.Users.SingleOrDefault(x => x.Email == user.Email);

            oldUser.Email = user.Email;
            oldUser.Name = user.Name;

            if (user.Picture.Any())
            {
                oldUser.Picture = user.Picture;
            }

            if (!String.IsNullOrEmpty(user.HashPassword))
            {
                oldUser.HashPassword = _passwordHasher.HashPassword(oldUser, user.HashPassword);
            }

            _context.SaveChanges();
        }
    }
}
