using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUCFour.Model.Model;

namespace TheUCFour.Models
{
    public class SaleDetialsViewModel
    {
        public int Id { get; set; }
        public float Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public float MRP { get; set; }
        public float TotalMRP { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public List<SelectListItem> ProductSelectListItems { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<SelectListItem> CategorySelectListItems { get; set; }
        public List<SaleDetials> SaleDetials { get; set; }
    }
}