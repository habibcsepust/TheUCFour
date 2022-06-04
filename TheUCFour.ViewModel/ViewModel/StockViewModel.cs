using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheUCFour.Models
{
    public class StockViewModel
    {
        public string Code { get; set; }
        public string Date { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public double ReorderLevel { get; set; }
        public int openingQty { get; set; }
        public int INQty { get; set; }
        public int OutQty { get; set; }
        public int DayCloseQty { get; set; }
    }
}