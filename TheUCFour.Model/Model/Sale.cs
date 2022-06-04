using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUCFour.Model.Model
{
    public class Sale
    {
        public Sale()
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
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<SaleDetials> SaleDetials { get; set; }
    }
}
