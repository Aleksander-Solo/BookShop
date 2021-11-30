using BookShop.DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Cover> Covers { get; set; }
        public DbSet<TypeOfBook> TypesOfBook { get; set; }
        public DbSet<PublishingHause> PublishingHauses { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistory { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(x => x.Title).HasMaxLength(45).IsRequired();
            modelBuilder.Entity<Book>().Property(x => x.Author).HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(x => x.Description).HasColumnType("TEXT");

            modelBuilder.Entity<Comment>().Property(x => x.Title).HasMaxLength(25).IsRequired();
            modelBuilder.Entity<Comment>().Property(x => x.Stars).HasMaxLength(10);

            modelBuilder.Entity<Cover>().Property(x => x.Name).HasMaxLength(30).IsRequired();

            modelBuilder.Entity<TypeOfBook>().Property(x => x.Name).HasMaxLength(35).IsRequired();

            modelBuilder.Entity<PublishingHause>().Property(x => x.Name).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<PublishingHause>().Property(x => x.PhoneNumber).HasMaxLength(16);

            modelBuilder.Entity<Role>().Property(x => x.Name).IsRequired();

            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(30);
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.HashPassword).IsRequired();

            modelBuilder.Entity<Cover>().HasData(new Cover { Id = 1, Name = "Twarda" });
            modelBuilder.Entity<Cover>().HasData(new Cover { Id = 2, Name = "Miękka" });

            modelBuilder.Entity<TypeOfBook>().HasData(new TypeOfBook { Id = 1, Name = "Fantazy" });
            modelBuilder.Entity<TypeOfBook>().HasData(new TypeOfBook { Id = 2, Name = "Dramat" });

            modelBuilder.Entity<PurchaseHistory>().Property(x => x.FirstName).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<PurchaseHistory>().Property(x => x.LastName).HasMaxLength(50).IsRequired();
        }
    }
}
