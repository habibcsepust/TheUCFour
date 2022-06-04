using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUCFour.DatabaseContext.DatabaseContext;
using TheUCFour.Model.Model;
using TheUCFour.ViewModel.ViewModel;

namespace TheUCFour.Repository.Repository
{
    public class PurchaseReportRepository
    {
        string connectionString = @"Server = HABIB; Database = TheUCFour;
                Integrated Security = true";


        public List<PurchaseView1> LoadProducts()
        {
            List<PurchaseView1> purchaseView1s = new List<PurchaseView1>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = "SELECT * FROM PurchaseView1";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                PurchaseView1 purchaseView1 = new PurchaseView1();
                purchaseView1.Product = sqlDataReader["Product"].ToString();
                purchaseView1.Date = sqlDataReader["Date"].ToString();
                purchaseView1.AvailableQuantity = Convert.ToDouble(sqlDataReader["AvailableQuantity"].ToString());
                purchaseView1.UnitPrice = Convert.ToDouble(sqlDataReader["UnitPrice"].ToString());
                purchaseView1.MRP = Convert.ToDouble(sqlDataReader["MRP"].ToString());
                purchaseView1.Profit = Convert.ToDouble(sqlDataReader["Profit"].ToString());

                purchaseView1s.Add(purchaseView1);
            }
            sqlConnection.Close();

            return purchaseView1s;
        }


        //double availableQuantity;
        //public double GetAvailableProduct(int productId)
        //{
        //    SqlConnection sqlConnection = new SqlConnection(connectionString);
        //    sqlConnection.Open();
        //    string query = "SELECT AvailableQuantity FROM PurchaseView1 WHERE ProductId = " + productId+ " ORDER BY AvailableQuantity DESC";
        //    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

        //    DataTable dataTable = new DataTable();
        //    int isFill = sqlDataAdapter.Fill(dataTable);

        //    if (dataTable.Rows.Count > 0)
        //    {

        //        availableQuantity = double.Parse(dataTable.Rows[0][0].ToString());
        //    }
        //    return availableQuantity;
        //}

        public List<PurchaseView1> SearchProducts(PurchaseView1 purchaseView1)
        {
            List<PurchaseView1> purchaseView1s = new List<PurchaseView1>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            string query = @"SELECT * FROM PurchaseView1 WHERE Date BETWEEN '" + purchaseView1.StartDate + "' AND '" + purchaseView1.EndDate + "'";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                PurchaseView1 purchaseView = new PurchaseView1();
                purchaseView.Product = sqlDataReader["Product"].ToString();
                purchaseView.Date = sqlDataReader["Date"].ToString();
                purchaseView.AvailableQuantity = Convert.ToDouble(sqlDataReader["AvailableQuantity"].ToString());
                purchaseView.UnitPrice = Convert.ToDouble(sqlDataReader["UnitPrice"].ToString());
                purchaseView.MRP = Convert.ToDouble(sqlDataReader["MRP"].ToString());
                purchaseView.Profit = Convert.ToDouble(sqlDataReader["Profit"].ToString());

                purchaseView1s.Add(purchaseView);
            }
            sqlConnection.Close();

            return purchaseView1s;
        }

        double availableQuantity;
        public double GetAvailableProduct(int productId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            
            string query = "SELECT TOP 1  SUM(pd.Quantity) as AvailableQuantity " +
                "FROM PurchaseDetails AS pd INNER JOIN Products AS p ON pd.ProductId = " +
                ""+ productId + " GROUP BY p.Name,p.Id";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {

                availableQuantity = double.Parse(dataTable.Rows[0][0].ToString());
            }
            return availableQuantity;
        }



        double saleQuantity;
        public double GetSaleAvailableProduct(int productId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string query = "SELECT TOP 1 SUM(sd.Quantity) as AvailableQuantity " +
                "FROM SaleDetials AS sd INNER JOIN Products AS p ON " +
                "sd.ProductId = "+ productId + " GROUP BY p.Name,p.Id";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {

                saleQuantity = double.Parse(dataTable.Rows[0][0].ToString());
            }
            return saleQuantity;
        }

        public double GetAvailableQtyByProductIdFrmPurchase(int productId)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            string query = @"SElect ProductId, sum(AvailableQuantity) as Quantity  from PurchaseDetails where ProductId =2 group by ProductId";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {

                availableQuantity = double.Parse(dataTable.Rows[0][0].ToString());
            }
            return availableQuantity;
        }
    }
}
