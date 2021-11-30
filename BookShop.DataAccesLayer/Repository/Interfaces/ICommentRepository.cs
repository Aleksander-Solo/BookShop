using BookShop.DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Repository.Interfaces
{
    public interface ICommentRepository
    {
        public void AddComment(Comment comment);
        public void DeleteComment(int id);
    }
}
