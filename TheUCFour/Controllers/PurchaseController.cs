using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUCFour.Model.Model;
using TheUCFour.Models;
using TheUCFour.BLL.BLL;
using TheUCFour.ViewModel.ViewModel;
using AutoMapper;

namespace TheUCFour.Controllers
{
    public class PurchaseController : Controller
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        SupplierManager _supplierManager = new SupplierManager();
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        PurchaseView1 _purchaseView1 = new PurchaseView1();
        PurchaseReportManager _purchaseReportManager = new PurchaseReportManager();

        public ActionResult AddPurchase()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            PurchaseDetailsViewModel purchaseDetailsViewModel = new PurchaseDetailsViewModel();
            
            purchaseViewModel.SupplierSelectListItems = _supplierManager
                                                        .GetAll()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Name
                                                        }).ToList();
            purchaseDetailsViewModel.CategorySelectListItems = _categoryManager
                                                       .GetAll()
                                                       .Select(c => new SelectListItem()
                                                       {
                                                           Value = c.Id.ToString(),
                                                           Text = c.Name
                                                       }).ToList();
            ViewBag.CategoryId = purchaseDetailsViewModel.CategorySelectListItems;

            purchaseViewModel.Purchases = _purchaseManager.GetAllPurchase();
            return View(purchaseViewModel);
        }


        [HttpPost]
        public ActionResult AddPurchase(PurchaseViewModel purchaseViewModel)
        {
            Purchase purchase = Mapper.Map<Purchase>(purchaseViewModel);
            _purchaseManager.Add(purchase);
            PurchaseDetailsViewModel purchaseDetailsViewModel = new PurchaseDetailsViewModel();
            purchaseViewModel.SupplierSelectListItems = _supplierManager
                                                       .GetAll()
                                                       .Select(c => new SelectListItem()
                                                       {
                                                           Value = c.Id.ToString(),
                                                           Text = c.Name
                                                       }).ToList();
            purchaseDetailsViewModel.CategorySelectListItems = _categoryManager
                                                       .GetAll()
                                                       .Select(c => new SelectListItem()
                                                       {
                                                           Value = c.Id.ToString(),
                                                           Text = c.Name
                                                       }).ToList();
            ViewBag.CategoryId = purchaseDetailsViewModel.CategorySelectListItems;
            purchaseViewModel.Purchases = _purchaseManager.GetAllPurchase();

            return View(purchaseViewModel);
        }


        public JsonResult GetProductByCategoryId(int? categoryId)
        {
            var productList = _productManager.GetAll().Where(c => c.CategoryId == categoryId).ToList();
            var products = from p in productList select (new { p.Id, p.Name });
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCodeByProductId(int? productId)
        {
            var productList = _productManager.GetAll().Where(c => c.Id == productId).ToList();
            var products = from p in productList select (new { p.Code });
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPreviousUnitPriceByProductId(int? productId)
        {
            var purchsaeList = _purchaseManager.GetAllForPreviousUnitPrice().OrderByDescending(c => c.ProductId == productId).ToList().FirstOrDefault();
            //var previousUnitPrice = from purchsaeList select(new { p.PreviousUnitPrice });
            return Json(purchsaeList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetAvailableQtyByProductId(int productId)
        {
            var getAvailableProduct = _purchaseReportManager.GetAvailableProduct(productId);
            var getSaleAvailableProduct = _purchaseReportManager.GetSaleAvailableProduct(productId);

            if (getSaleAvailableProduct > 0)
            {
                getAvailableProduct = getAvailableProduct - getSaleAvailableProduct;
            }

            return Json(getAvailableProduct, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SupplierDetails()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.Purchases = _purchaseManager.GetAllPurchase();
            return View(purchaseViewModel);
        }


        //Show Purchase Details
        public ActionResult PurchaseDetails( int id)
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.Purchases = _purchaseManager.GetAllPurchase().Where(c=>c.Id == id).ToList();
            ViewBag.Category = _categoryManager.GetAll();

            PurchaseDetailsViewModel purchaseDetailsViewModel = new PurchaseDetailsViewModel();
            purchaseDetailsViewModel.PurchaseDetails = _purchaseManager.GetAll().Where(c=>c.PurchaseId == id).ToList();
            ViewBag.Details = purchaseDetailsViewModel.PurchaseDetails;
            return View(purchaseViewModel);
        }

        public ActionResult EditPurchaseDetails(int id)
        {
            PurchaseDetailsViewModel purchaseDetailsViewModel = new PurchaseDetailsViewModel();
            purchaseDetailsViewModel.PurchaseDetails = _purchaseManager.GetAll().Where(c=>c.Id == id).ToList();

            //PurchaseDetailsViewModel purchaseDetailsViewModel = new PurchaseDetailsViewModel();
            purchaseDetailsViewModel.CategorySelectListItems = _categoryManager
                                                       .GetAll()
                                                       .Select(c => new SelectListItem()
                                                       {
                                                           Value = c.Id.ToString(),
                                                           Text = c.Name
                                                       }).ToList();
            ViewBag.CategoryId = purchaseDetailsViewModel.CategorySelectListItems;
            return View(purchaseDetailsViewModel);
        }

        [HttpPost]
        public ActionResult EditPurchaseDetails(PurchaseDetailsViewModel purchaseDetailsViewModel)
        {
            string message = "";
           
                PurchaseDetails purchaseDetails = Mapper.Map<PurchaseDetails>(purchaseDetailsViewModel);

                purchaseDetailsViewModel.CategorySelectListItems = _categoryManager
                                                       .GetAll()
                                                       .Select(c => new SelectListItem()
                                                       {
                                                           Value = c.Id.ToString(),
                                                           Text = c.Name
                                                       }).ToList();
                ViewBag.CategoryId = purchaseDetailsViewModel.CategorySelectListItems;


                if (_purchaseManager.Update(purchaseDetails))
                {
                    message = "Updated Successfully..";
                }
                else
                {
                    message = "No Change Your Update Information";
                }
            
            purchaseDetailsViewModel.PurchaseDetails = _purchaseManager.GetAll().Where(c => c.Id == purchaseDetailsViewModel.Id).ToList();
            ViewBag.Message = message;
            return View(purchaseDetailsViewModel);
        }

        public JsonResult CheckDuplicateInvoiceNo(string InvoiceNo)
        {
            var purchaseList = _purchaseManager.GetAllPurchase().Where(c => c.InvoiceNo == InvoiceNo).ToList();
            var invoiceNo = from p in purchaseList select (new { p.InvoiceNo });
            return Json(invoiceNo, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult SearchSupplier(string SearchData)
        //{
        //    List<Purchase> suppliers = _purchaseManager.GetAllPurchase();
        //    var date = suppliers.Where(c => c.Date.Contains(SearchData)).ToList();
        //    var name = suppliers.Where(c => c.Supplier.Name.Contains(SearchData)).ToList();
        //    var invoiceNo = suppliers.Where(c => c.InvoiceNo.Contains(SearchData)).ToList();
        //    if (date.Count() != 0)
        //    {
        //        return Json(date, JsonRequestBehavior.AllowGet);
        //    }

        //    if (name.Count() != 0)
        //    {
        //        return Json(name, JsonRequestBehavior.AllowGet);
        //    }

        //    if (invoiceNo.Count() != 0)
        //    {
        //        return Json(invoiceNo, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(null, JsonRequestBehavior.AllowGet);
        //}

    }
}


