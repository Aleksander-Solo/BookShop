using BookShop.DataAccesLayer.Repository.Interfaces;
using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.DataAccesLayer.Entities;

namespace BookShop.Services
{
    public class PurchaseHistoryService : IPurchaseHistoryService
    {
        private readonly IPurchaseHistoryRepository _repository;
        private readonly MapperConfig _mapper;

        public PurchaseHistoryService(IPurchaseHistoryRepository repository, MapperConfig mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(PurchaseHistoryViewModel purchase)
        {
            PurchaseHistory purchaseHistory = new PurchaseHistory
            {
                FirstName = purchase.FirstName,
                LastName = purchase.LastName,
                Adress = purchase.Adress,
                BuyerId = purchase.BuyerId,
                Books = _mapper.Map(purchase.Books),
                ToPay = purchase.ToPay
            };

            _repository.Create(purchaseHistory);
        }

        public List<PurchaseHistoryViewModel> Get()
        {
            return _mapper.Map(_repository.Get());
        }
    }
}
