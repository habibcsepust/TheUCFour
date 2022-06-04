using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUCFour.BLL.BLL;
using TheUCFour.Models;
using TheUCFour.Model.Model;
using AutoMapper;

namespace TheUCFour.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();

        //******************Add Customer*********************
        public ActionResult AddCustomer()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerViewModel customerViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Customer customer = Mapper.Map<Customer>(customerViewModel);
                customerViewModel.Customers = _customerManager.GetAll();
                bool isExistCustomerCode = _customerManager.ExistCuctomerCode(customer);
                if (isExistCustomerCode)
                {
                    ViewBag.existDuplicate = "Code is Already Exist..";
                    return View(customerViewModel);
                }
                bool isExistCustomerEmail = _customerManager.ExistCuctomerEmail(customer);
                if (isExistCustomerEmail)
                {
                    ViewBag.existDuplicate = "Email is Already Exist..";
                    return View(customerViewModel);
                }
                bool isExistCustomerContact = _customerManager.ExistCuctomerContact(customer);
                if (isExistCustomerContact)
                {
                    ViewBag.existDuplicate = "Contact is Already Exist..";
                    return View(customerViewModel);
                }
                if (_customerManager.Add(customer))
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
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }

        //******************Search Customer*********************
        public ActionResult SearchCustomer()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult SearchCustomer(CustomerViewModel customerViewModel)
        {
            var customers = _customerManager.GetAll();

            if (customerViewModel.Code != null)
            {
                customers = customers.Where(c => c.Code.Contains(customerViewModel.Code)).ToList();
            }
            if (customerViewModel.Name != null)
            {
                customers = customers.Where(c => c.Name.ToUpper().Contains(customerViewModel.Name.ToUpper())).ToList();
            }
            if (customerViewModel.Email != null)
            {
                customers = customers.Where(c => c.Email.ToUpper().Contains(customerViewModel.Email.ToUpper())).ToList();
            }
            if (customerViewModel.Contact != null)
            {
                customers = customers.Where(c => c.Contact.ToUpper().Contains(customerViewModel.Contact.ToUpper())).ToList();
            }

            customerViewModel.Customers = customers;
            return View(customerViewModel);
        }

        //******************Update Customer*********************
        public ActionResult EditCustomer(int id)
        {
            var customer = _customerManager.GetById(id);
            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(customer);
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult EditCustomer(CustomerViewModel customerViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Customer customer = Mapper.Map<Customer>(customerViewModel);

                if (_customerManager.Update(customer))
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
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }

        //******************Delete Customer*********************
        public ActionResult DeleteCustomer(int id)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            var customer = _customerManager.Delete(id);
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }

        //***************Show By Id*****************
        public ActionResult ShowByIdCustomer(int id)
        {
            Customer customer = _customerManager.GetById(id);
            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(customer);
            return View(customerViewModel);
        }
    }
}