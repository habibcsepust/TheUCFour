using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheUCFour.Models;

namespace TheUCFour.Controllers
{
    public class StockController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.searchresult = "";
            //StudentData sd = new StudentData();
            StockViewModel stockViewModel = new StockViewModel();
            //sd.rollno = "";
            //sd.sname = "";
            //sd.fname = "";
            //sd.mname = "";
            stockViewModel.Code = "";
            stockViewModel.Date = "";
            stockViewModel.CategoryName = "";
            stockViewModel.ProductName = "";
            stockViewModel.ReorderLevel = 0;
            stockViewModel.openingQty = 0;
            stockViewModel.INQty = 0;
            stockViewModel.OutQty = 0;
            stockViewModel.DayCloseQty = 0;

            return View(stockViewModel);
        }

        [HttpPost]
        public ActionResult Index(string Date, string Date2)
        {
            StockViewModel stockViewModel = new StockViewModel();
            DataSet ds = new DataSet();
            String constring = "Data Source=HABIB; Initial Catalog=TheUCFour; Integrated Security=true";
            SqlConnection sqlcon = new SqlConnection(constring);
            String pname = "CloseQtyForStock";
            sqlcon.Open();
            SqlCommand com = new SqlCommand(pname, sqlcon);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@date1", Date);
            com.Parameters.AddWithValue("@date2", Date2);
            SqlDataReader dr;
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                //ViewBag.searchresult = "Roll Number Has Been Found";
                stockViewModel.Date = Date;
                stockViewModel.Code = dr["Code"].ToString();
                stockViewModel.CategoryName = dr["CategoryName"].ToString();
                stockViewModel.ProductName = dr["ProductName"].ToString();
                stockViewModel.ReorderLevel = Convert.ToDouble(dr["ReorderLevel"].ToString());
                stockViewModel.openingQty = Convert.ToInt32(dr["openingQty"].ToString());
                stockViewModel.INQty = Convert.ToInt32(dr["INQty"].ToString());
                stockViewModel.OutQty = Convert.ToInt32(dr["OutQty"].ToString());
                stockViewModel.DayCloseQty = Convert.ToInt32(dr["DayCloseQty"].ToString());

            }
            else
            {

                stockViewModel.Code = "";
                stockViewModel.CategoryName = "";
                stockViewModel.ProductName = "";
                stockViewModel.ReorderLevel = 0;
                stockViewModel.openingQty = 0;
                stockViewModel.INQty = 0;
                stockViewModel.OutQty = 0;
                stockViewModel.DayCloseQty = 0;

                ViewBag.searchresult = "Roll Number Not Found";
            }


            sqlcon.Close();


            return View(stockViewModel);
        }
    }
}