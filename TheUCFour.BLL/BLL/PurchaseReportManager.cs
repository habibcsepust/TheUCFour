using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUCFour.ViewModel.ViewModel;
using TheUCFour.Repository.Repository;

namespace TheUCFour.BLL.BLL
{
    public class PurchaseReportManager
    {
        PurchaseReportRepository _purchaseReportRepository = new PurchaseReportRepository();
        public List<PurchaseView1> LoadProducts()
        {
            return _purchaseReportRepository.LoadProducts();
        }

        public double GetAvailableProduct(int productId)
        {
            return _purchaseReportRepository.GetAvailableProduct(productId);
        }

        public double GetSaleAvailableProduct(int productId)
        {
            return _purchaseReportRepository.GetSaleAvailableProduct(productId);
        }

        public List<PurchaseView1> SearchProducts(PurchaseView1 purchaseView1)
        {
            return _purchaseReportRepository.SearchProducts(purchaseView1);
        }
        public double GetAvailableQtyByProductIdFrmPurchase(int productId)
        {
            return _purchaseReportRepository.GetAvailableQtyByProductIdFrmPurchase(productId);
        }
    }
}
