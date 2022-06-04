using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheUCFour.Models
{
    public class SalesReportViewModel
    {
        public SalesReportViewModel()
        {
            SalesReport = new List<SalesReportViewModel>();
        }
        public DateTime Date { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Category { set; get; }
        public double Soldqty { set; get; }
        public double CP { set; get; }
        public double SalesPrice { set; get; }
        public double Profit { set; get; }
        public List<SalesReportViewModel> SalesReport { set; get; }
    }
}