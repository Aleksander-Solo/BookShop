using BookShop.DataAccesLayer.Entities;
using BookShop.DataAccesLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            Comment comment = _context.Comments.FirstOrDefault(x => x.Id == id);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }
}
