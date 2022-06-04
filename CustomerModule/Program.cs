using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUCFour.Model.Model;
using TheUCFour.BLL.BLL;
using System.Data.SqlClient;

namespace CustomerModule
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager _customerManager = new CustomerManager();

            //Add Customer
            //Customer customer = new Customer()
            //{
            //    Code = "CU102",
            //    Name = "MD. Azimuddin",
            //    Address = "Jadurani",
            //    Email = "a@gmail.com",
            //    Contact = "01750752285",
            //    LoyalityPoint = 32
            //};
            //if (_customerManager.Add(customer))
            //{
            //    Console.WriteLine("Added");
            //}
            //else
            //{
            //    Console.WriteLine("Not Added");
            //}

            //Update Customer
            //Customer customr = new Customer()
            //{
            //    Id = 2,
            //    Code = "CU102",
            //    Name = "MD. Msud",
            //    Address = "Thakurgaon",
            //    Email = "m@gmail.com",
            //    Contact = "01750751814",
            //    LoyalityPoint = 29
            //};
            //if (_customerManager.Update(customr))
            //{
            //    Console.WriteLine("Updated");
            //}
            //else
            //{
            //    Console.WriteLine("Not Updated");
            //}

            //Delete Customer
            //if (_customerManager.Delete(3))
            //{
            //    Console.WriteLine("Deleted");
            //}
            //else
            //{
            //    Console.WriteLine("Not Deleted");
            //}

            //For Display
            Console.WriteLine("For Multiple Customers");
            foreach (var cust in _customerManager.GetAll())
            {
                Console.WriteLine("Code:\t\t" + cust.Code + "\nName:\t\t" + cust.Name + "\nAddress:\t" +
                    cust.Address + "\nEmail:\t\t" + cust.Email + "\nContact:\t" + cust.Contact + "" +
                    "\nLoyalityPoint:\t" + cust.LoyalityPoint);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("For Single Customer");
            Customer customer = _customerManager.GetById(1);
            Console.WriteLine("Code: " + customer.Code + "   Name: " + customer.Name + "   Address: " +
                    customer.Address + "   Email: " + customer.Email + "   Contact: " + customer.Contact+"" +
                    "   LoyalityPoint: "+ customer.LoyalityPoint);


            Console.ReadKey();
        }
    }
}
