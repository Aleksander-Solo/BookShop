using BookShop.DataAccesLayer.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer
{
    public class ApplicationSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public ApplicationSeeder(ApplicationDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        private static readonly List<Role> Roles = new List<Role>()
        {
            new Role() { Name = "SuperAdmin"},
            new Role() { Name = "Admin"},
            new Role() { Name = "User"}
        };

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Roles.Any())
                {
                    _context.Roles.AddRange(Roles);
                    _context.SaveChanges();
                }

                if (!_context.Users.Any())
                {
                    User user = new User() { Name = "Mr. S-Admin", Email = "superAdmin@wp.pl", RoleId = 1 };
                    user.HashPassword = _passwordHasher.HashPassword(user, "Secret123");

                    _context.Users.Add(user);
                    _context.SaveChanges();
                }
            }
        }
    }
}
