using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public interface ICoverAndTypeService
    {
        public void AddCover(CoverViewModel cover);
        public void AddType(TypeOfBookViewModel type);
        public void DelateType(int id);
        public void DelateCover(int id);
        public List<CoverViewModel> GetCovers();
        public List<TypeOfBookViewModel> GetTypes();
    }
}
