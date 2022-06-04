using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUCFour.Models;
using TheUCFour.Model.Model;
using TheUCFour.BLL.BLL;
using AutoMapper;

namespace TheUCFour.Controllers
{
    public class ProductController : Controller
    {
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();

        //******************Add Product*********************
        [HttpGet]
        public ActionResult AddProduct()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = _productManager.GetAll();
            productViewModel.ProductSelectListItems = _categoryManager
                                                        .GetAll()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Name
                                                        }).ToList();

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult AddProduct(ProductViewModel productViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Product product = Mapper.Map<Product>(productViewModel);
                productViewModel.Products = _productManager.GetAll();//Get All Product

                productViewModel.ProductSelectListItems = _categoryManager//Get All Category
                                                        .GetAll()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Name
                                                        }).ToList();
                bool isExistProductCode = _productManager.ExistProductCode(product);
                if (isExistProductCode)
                {
                    ViewBag.existDuplicate = "Code is Already Exist..";
                    return View(productViewModel);
                }

                bool isExistProductName = _productManager.ExistProductName(product);
                if (isExistProductName)
                {
                    ViewBag.existDuplicate = "Name is Already Exist..";
                    return View(productViewModel);
                }

                if (_productManager.Add(product))
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
            productViewModel.Products = _productManager.GetAll();//Get All Product
            return View(productViewModel);
        }

        //******************Search Product*********************
        [HttpGet]
        public ActionResult SearchProduct()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = _productManager.GetAll();
            productViewModel.ProductSelectListItems = _categoryManager
                                                        .GetAll()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Name
                                                        }).ToList();

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult SearchProduct(ProductViewModel productViewModel)
        {
            var products = _productManager.GetAll();

            if (productViewModel.Code != null)
            {
                products = products.Where(c => c.Code.Contains(productViewModel.Code)).ToList();
            }
            if (productViewModel.Name != null)
            {
                products = products.Where(c => c.Name.ToUpper().Contains(productViewModel.Name.ToUpper())).ToList();
            }

            productViewModel.Products = products;
            productViewModel.ProductSelectListItems = _categoryManager
                                                        .GetAll()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Name
                                                        }).ToList();
            return View(productViewModel);
        }

        //******************Update Product*********************
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            Product product = _productManager.GetById(id);
            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(product);
            productViewModel.Products = _productManager.GetAll();
            productViewModel.ProductSelectListItems = _categoryManager
                                                        .GetAll()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Name
                                                        }).ToList();

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductViewModel productViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Product product = Mapper.Map<Product>(productViewModel);

                if (_productManager.Update(product))
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
            productViewModel.Products = _productManager.GetAll();
            productViewModel.ProductSelectListItems = _categoryManager
                                                        .GetAll()
                                                        .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Name
                                                        }).ToList();
            return View(productViewModel);
        }

        //***************Show By Id*****************
        public ActionResult ShowByIdProduct(int id)
        {
            Product product = _productManager.GetById(id);
            return View(product);
        }

    }
}