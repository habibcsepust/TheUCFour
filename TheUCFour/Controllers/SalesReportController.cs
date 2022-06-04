using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUCFour.BLL.BLL;
using TheUCFour.Models;

namespace TheUCFour.Controllers
{
    public class SalesReportController : Controller
    {

        PurchaseManager _purchaseManager = new PurchaseManager();
        SalesManager _salesManager = new SalesManager();

        PurchaseDetailsViewModel _purchaseDetailsViewModel = new PurchaseDetailsViewModel();

        public ActionResult SaleReport()
        {
            SalesReportViewModel salesReportViewModel = new SalesReportViewModel();

            var purchaseDetails = _purchaseManager.GetAll();
            var salesDetails = _salesManager.GetAllSaleDetails();
            var report = (from sa in salesDetails
                          join pu in purchaseDetails on sa.ProductId equals pu.ProductId
                          select new SalesReportViewModel
                          {
                              Date = sa.Sale.Date,
                              Code = sa.Product.Code,
                              Name = sa.Product.Name,
                              Category = sa.Category.Name,
                              Soldqty = sa.Quantity,
                              CP = sa.Quantity * pu.UnitPrice,
                              SalesPrice = sa.Quantity * pu.MRP,
                              Profit = sa.Quantity * pu.MRP - sa.Quantity * pu.UnitPrice


                          }).ToList();

            salesReportViewModel.SalesReport = report;

            return View(salesReportViewModel);
        }

        [HttpPost]
        public ActionResult SaleReport(DateTime? startdate, DateTime? enddate)
        {
            SalesReportViewModel salesReportViewModel = new SalesReportViewModel();

            var purchaseDetails = _purchaseManager.GetAll();
            var salesDetails = _salesManager.GetAllSaleDetails();
            var report = (from sa in salesDetails
                          join pu in purchaseDetails on sa.ProductId equals pu.ProductId
                          where sa.Sale.Date >= startdate && sa.Sale.Date <= enddate
                          select new SalesReportViewModel
                          {
                              Date = sa.Sale.Date,
                              Code = sa.Product.Code,
                              Name = sa.Product.Name,
                              Category = sa.Category.Name,
                              Soldqty = sa.Quantity,
                              CP = sa.Quantity * pu.UnitPrice,
                              SalesPrice = sa.Quantity * pu.MRP,
                              Profit = sa.Quantity * pu.MRP - sa.Quantity * pu.UnitPrice


                          }).ToList();

            salesReportViewModel.SalesReport = report;

            return View(salesReportViewModel);
        }
    }
}