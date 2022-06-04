using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUCFour.Repository.Repository;
using TheUCFour.Model.Model;

namespace TheUCFour.BLL.BLL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();

        public bool Add(Purchase purchase)
        {
            return _purchaseRepository.Add(purchase);
        }

        public List<PurchaseDetails> GetAll()
        {
            return _purchaseRepository.GetAll();
        }

        public List<PurchaseDetails> GetAllForPreviousUnitPrice()
        {
            return _purchaseRepository.GetAllForPreviousUnitPrice();
        }

        public List<Purchase> GetAllPurchase()
        {
            return _purchaseRepository.GetAllPurchase();
        }

        public bool Update(PurchaseDetails purchaseDetails)
        {
            return _purchaseRepository.Update(purchaseDetails);
        }
    }
}
