using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUCFour.Repository.Repository;
using TheUCFour.Model.Model;

namespace TheUCFour.BLL.BLL
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();
        public bool Add(Sale sale)
        {
            return _salesRepository.Add(sale);
        }

        public List<Sale> GetAllSale()
        {
            return _salesRepository.GetAllSale();
        }

        public List<SaleDetials> GetAllSaleDetails()
        {
            return _salesRepository.GetAllSaleDetails();
        }

        public List<SaleDetials> GetPreviousMRP()
        {
            return _salesRepository.GetPreviousMRP();
        }
        public List<Sale> GetAll()
        {
            return _salesRepository.GetAll();
        }
    }
}
//public List<PurchaseDetails> GetAll()
//{
//    return _purchaseRepository.GetAll();
//}
//public List<PurchaseDetails> GetAll()
//{
//    return _purchaseRepository.GetAll();
//}
//public List<PurchaseDetails> GetAll()
//{
//    return _purchaseRepository.GetAll();
//}