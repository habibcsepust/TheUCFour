using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUCFour.BLL.BLL;
using TheUCFour.Model.Model;
using TheUCFour.Models;
using AutoMapper;

namespace TheUCFour.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();

        //******************Add Supplier*********************
        public ActionResult AddSupplier()
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult AddSupplier(SupplierViewModel supplierViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);
                supplierViewModel.Suppliers = _supplierManager.GetAll();
                bool isExistSupplierCode = _supplierManager.ExistSupplierCode(supplier);
                if (isExistSupplierCode)
                {
                    ViewBag.existDuplicate = "Code is Already Exist..";
                    return View(supplierViewModel);
                }
                bool isExistSupplierEmail = _supplierManager.ExistSupplierEmail(supplier);
                if (isExistSupplierEmail)
                {
                    ViewBag.existDuplicate = "Email is Already Exist..";
                    return View(supplierViewModel);
                }
                bool isExistSupplierContact = _supplierManager.ExistSupplierContact(supplier);
                if (isExistSupplierContact)
                {
                    ViewBag.existDuplicate = "Contact is Already Exist..";
                    return View(supplierViewModel);
                }
                if (_supplierManager.Add(supplier))
                {
                    message = "Saved Successfully..";
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                ViewBag.InvalidModel = "ModelState is invalied!";
            }

            ViewBag.Message = message;
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }

        //******************Search Supplier*********************
        public ActionResult SearchSuuplier()
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult SearchSuuplier(SupplierViewModel supplierViewModel)
        {
            var suppliers = _supplierManager.GetAll();

            if (supplierViewModel.Code != null)
            {
                suppliers = suppliers.Where(c => c.Code.Contains(supplierViewModel.Code)).ToList();
            }
            if (supplierViewModel.Name != null)
            {
                suppliers = suppliers.Where(c => c.Name.ToUpper().Contains(supplierViewModel.Name.ToUpper())).ToList();
            }
            if (supplierViewModel.Email != null)
            {
                suppliers = suppliers.Where(c => c.Email.ToUpper().Contains(supplierViewModel.Email.ToUpper())).ToList();
            }
            if (supplierViewModel.Contact != null)
            {
                suppliers = suppliers.Where(c => c.Contact.ToUpper().Contains(supplierViewModel.Contact.ToUpper())).ToList();
            }

            supplierViewModel.Suppliers = suppliers;
            return View(supplierViewModel);
        }

        //******************Update Suuplier*********************
        public ActionResult EditSupplier(int id)
        {
            var supplier = _supplierManager.GetById(id);
            SupplierViewModel supplierViewModel = Mapper.Map<SupplierViewModel>(supplier);
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult EditSupplier(SupplierViewModel supplierViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);

                if (_supplierManager.Update(supplier))
                {
                    message = "Updated Successfully..";
                }
                else
                {
                    message = "No Change Your Update Information";
                }
            }
            else
            {
                ViewBag.InvalidModel = "ModelState is invalied!";
            }

            ViewBag.Message = message;
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }

        //***************Show By Id*****************
        public ActionResult ShowByIdSupplier(int id)
        {
            Supplier supplier = _supplierManager.GetById(id);
            SupplierViewModel supplierViewModel = Mapper.Map<SupplierViewModel>(supplier);
            return View(supplierViewModel);
        }

        //******************Delete Supplier*********************
        public ActionResult DeleteSupplier(int id)
        {
            SupplierViewModel supplierViewModell = new SupplierViewModel();
            var customer = _supplierManager.Delete(id);
            supplierViewModell.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModell);
        }
    }
}