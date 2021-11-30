using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public interface ICommentService
    {
        public void AddComment(CommentViewModel comment);
        public void DeleteComment(int id);
    }
}
