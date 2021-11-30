using BookShop.DataAccesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccesLayer.Repository.Interfaces
{
    public interface ICoverAndTypeRepository
    {
        public void AddCover(Cover cover);
        public void AddType(TypeOfBook type);
        public void DelateType(int id);
        public void DelateCover(int id);
        public List<Cover> GetCovers();
        public List<TypeOfBook> GetTypes();
    }
}
