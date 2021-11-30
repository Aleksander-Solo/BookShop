using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Services
{
    public interface IPurchaseHistoryService
    {
        public void Create(PurchaseHistoryViewModel purchase);
        public List<PurchaseHistoryViewModel> Get();
    }
}
