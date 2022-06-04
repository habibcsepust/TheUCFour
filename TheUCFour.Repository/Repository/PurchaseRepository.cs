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
    public class PurchaseRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool Add(Purchase purchase)
        {
            _dbContext.Purchases.Add(purchase);
            return _dbContext.SaveChanges() > 0;
        }

        public List<Purchase> GetAllPurchase()
        {
            var purchases = _dbContext.Purchases.Include(p => p.Supplier).ToList();
            return purchases;
        }

        public List<PurchaseDetails> GetAll()
        {
            //var purchaseDetails = _dbContext.PurchaseDetails.Include(p=>p.Product).ToList();
            var purchaseDetails = _dbContext.PurchaseDetails.Include(c => c.Purchase).Include(c => c.Product).Include(c => c.Product.Category).ToList();
            return purchaseDetails;
        }

        public List<PurchaseDetails> GetAllForPreviousUnitPrice()
        {
            var purchaseDetails = _dbContext.PurchaseDetails.Include(p=>p.Product).ToList();
            //var purchaseDetails = _dbContext.PurchaseDetails.Include(c => c.Purchase).Include(c => c.Product).Include(c => c.Product.Category).ToList();
            return purchaseDetails;
        }

        public bool Update(PurchaseDetails purchaseDetails)
        {
            PurchaseDetails singleProduct = _dbContext.PurchaseDetails.FirstOrDefault(c => c.Id == purchaseDetails.Id);
            if (singleProduct != null)
            {
                singleProduct.CategoryId = purchaseDetails.CategoryId;
                singleProduct.ProductId = purchaseDetails.ProductId;
                singleProduct.Code = purchaseDetails.Code;
                singleProduct.ManufactureDate = purchaseDetails.ManufactureDate;
                singleProduct.ExpireDate = purchaseDetails.ExpireDate;
                singleProduct.Quantity = purchaseDetails.Quantity;
                singleProduct.UnitPrice = purchaseDetails.UnitPrice;
                singleProduct.TotalPrice = purchaseDetails.TotalPrice;
                singleProduct.PreviousUnitPrice = purchaseDetails.PreviousUnitPrice;
                singleProduct.PreviousMRP = purchaseDetails.PreviousMRP;
                singleProduct.MRP = purchaseDetails.MRP;
                singleProduct.Remarks = purchaseDetails.Remarks;
            }

            return _dbContext.SaveChanges() > 0;
        }
    }
}
