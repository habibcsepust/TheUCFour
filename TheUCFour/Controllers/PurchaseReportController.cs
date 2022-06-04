using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUCFour.BLL.BLL;
using TheUCFour.ViewModel.ViewModel;
using TheUCFour.Models;
using TheUCFour.Model.Model;

namespace TheUCFour.Controllers
{
    public class PurchaseReportController : Controller
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        SalesManager _salesManager = new SalesManager();

        PurchaseDetailsViewModel _purchaseDetailsViewModel = new PurchaseDetailsViewModel();

        



        PurchaseReportManager _purchaseReportManager = new PurchaseReportManager();
        
        // GET: Report
        public ActionResult PurchaseReport()
        {
            PurchaseView1 purchaseView1 = new PurchaseView1();
            purchaseView1.PurchaseView1s = _purchaseReportManager.LoadProducts();
            return View(purchaseView1);
        }

        [HttpPost]
        public ActionResult PurchaseReport(PurchaseView1 purchaseView1)
        {
            //PurchaseView1 purchaseView1 = new PurchaseView1();
            purchaseView1.PurchaseView1s = _purchaseReportManager.SearchProducts(purchaseView1);
            return View(purchaseView1);
        }


        public ActionResult LoadPurchaseReport()
        {
            PurchaseReportViewModel _purchaseReportViewModel = new PurchaseReportViewModel();
            var purchase =  _purchaseManager.GetAllPurchase();
            var purchaseDetails =  _purchaseManager.GetAll();

            var sale = _salesManager.GetAllSale();
            var salesDetails = _salesManager.GetAllSaleDetails();

            //var purchaseDetails = _purchaseDetailsManager.GetAll();
            //var salesDetails = _saleDetailsManager.GetAll();
            var report = (from pu in purchaseDetails
                          join sa in salesDetails on pu.ProductId equals sa.ProductId
                          select new PurchaseReportViewModel
                          {
                              Date = pu.Purchase.Date,
                              Code = pu.Product.Code,
                              Name = pu.Product.Name,
                              Category = pu.Category.Name,
                              Availableqty = pu.Quantity - sa.Quantity,
                              CP = (pu.Quantity - sa.Quantity) * pu.UnitPrice,
                              SalesPrice = (pu.Quantity - sa.Quantity) * pu.MRP,
                              Profit = (pu.Quantity - sa.Quantity) * pu.MRP - (pu.Quantity - sa.Quantity) * pu.UnitPrice

                          }).ToList();
            _purchaseReportViewModel.PurchaseReport = report;


            return View(_purchaseReportViewModel);
        }

        [HttpPost]
        public ActionResult LoadPurchaseReport(DateTime? startdate, DateTime? enddate)
        {
            PurchaseReportViewModel _purchaseReportViewModel = new PurchaseReportViewModel();

            var purchaseDetails = _purchaseManager.GetAll();
            var salesDetails = _salesManager.GetAllSaleDetails();

            var report = (from pu in purchaseDetails
                          join sa in salesDetails on pu.ProductId equals sa.ProductId
                          where pu.Purchase.Date >= startdate && pu.Purchase.Date <= enddate
                          select new PurchaseReportViewModel
                          {
                              Date = pu.Purchase.Date,
                              Code = pu.Product.Code,
                              Name = pu.Product.Name,
                              Category = pu.Product.Category.Name,
                              Availableqty = pu.Quantity - sa.Quantity,
                              CP = (pu.Quantity - sa.Quantity) * pu.UnitPrice,
                              SalesPrice = (pu.Quantity - sa.Quantity) * pu.MRP,
                              Profit = (pu.Quantity - sa.Quantity) * pu.MRP - (pu.Quantity - sa.Quantity) * pu.UnitPrice

                          }).ToList();
            //if (_purchaseReportViewModel.Date != null)
            //{
            //    report = report.Where(c => c.Date > startdate && c.Date < enddate).ToList();
            //}

            _purchaseReportViewModel.PurchaseReport = report;
            return View(_purchaseReportViewModel);
        }
    }
}