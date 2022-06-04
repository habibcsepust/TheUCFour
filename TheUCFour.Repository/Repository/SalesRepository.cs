using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUCFour.Model.Model;
using TheUCFour.DatabaseContext.DatabaseContext;
using System.Data.Entity;

namespace TheUCFour.Repository.Repository
{
    public class SalesRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Sale sale)
        {
            _dbContext.Sales.Add(sale);
            return _dbContext.SaveChanges() > 0;
        }

        public List<Sale> GetAllSale()
        {
            return _dbContext.Sales.ToList();
        }

        public List<SaleDetials> GetAllSaleDetails()
        {
            //return _dbContext.SaleDetials.ToList();
            //var purchaseDetails = _dbContext.PurchaseDetails.Include(p => p.Product).ToList();
           //var saleDetials = _dbContext.SaleDetials.Include(p => p.Product).ToList();
            var saleDetials = _dbContext.SaleDetials.Include(c => c.Sale).Include(c => c.Product).Include(c => c.Product.Category).ToList();
            return saleDetials;
        }

        public List<SaleDetials> GetPreviousMRP()
        {
            var saleDetials = _dbContext.SaleDetials.Include(p => p.Product).ToList();
            return saleDetials;
        }
        public List<Sale> GetAll()
        {
            var sales = _dbContext.Sales.Include(c=>c.Customer).ToList();

            return sales;
        }

        //public List<SaleDetials> GetAllSaleDetails()
        //{
        //    var purchaseDetails = _dbContext.PurchaseDetails.Include(p => p.Product).ToList();
        //    return purchaseDetails;
        //}

    }
}
//var purchases = _dbContext.Purchases.Include(p => p.Supplier).ToList();
//            return purchases;

//public List<PurchaseDetails> GetAll()
//{
//    var purchaseDetails = _dbContext.PurchaseDetails.Include(p => p.Product).ToList();
//    return purchaseDetails;
//}