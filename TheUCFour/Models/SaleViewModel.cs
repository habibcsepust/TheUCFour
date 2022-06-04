using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUCFour.Model.Model;

namespace TheUCFour.Models
{
    public class SaleViewModel
    {
        public SaleViewModel()
        {
            SaleDetials = new List<SaleDetials>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public float GrandTotal { get; set; }
        public float Discount { get; set; }
        public float DiscountAmount { get; set; }
        public float PayableAmount { get; set; }
        public double LoyalityPoint { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<SaleDetials> SaleDetials { get; set; }
        public List<SelectListItem> CustomerSelectListItems { get; set; }
        public List<Sale> Sales { get; set; }
    }
}