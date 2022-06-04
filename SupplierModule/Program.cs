using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TheUCFour.BLL.BLL;
using TheUCFour.Model.Model;

namespace SupplierModule
{
    class Program
    {
        static void Main(string[] args)
        {
            SupplierManager _supplierManager = new SupplierManager();
            //Add Supplier
            //Supplier supplier = new Supplier()
            //{
            //    Code = "S101",
            //    Name = "MD. Habib",
            //    Address = "Dhaka",
            //    Email = "h@gmail.com",
            //    Contact = "017507522424",
            //    ContactPerson = "01752014315"
            //};
            //if (_supplierManager.Add(supplier))
            //{
            //    Console.WriteLine("Added");
            //}
            //else
            //{
            //    Console.WriteLine("Not Added");
            //}

            //Delete Supplier
            //if (_supplierManager.Delete(6))
            //{
            //    Console.WriteLine("Deleted");
            //}
            //else
            //{
            //    Console.WriteLine("Not Dleted");
            //}

            //Update Supplier
            //Supplier supplier = new Supplier()
            //{
            //    Id = 1,
            //    Code = "S103",
            //    Name = "MD. Abidur Rahman",
            //    Address = "Jadurani",
            //    Email = "abid@gmail.com",
            //    Contact = "017507522425",
            //    ContactPerson = "01752014325"
            //};
            //if (_supplierManager.Update(supplier))
            //{
            //    Console.WriteLine("Updated");
            //}
            //else
            //{
            //    Console.WriteLine("Not Updated");
            //}

            //For Display
            Console.WriteLine("For Multiple Suppliers");
            foreach (var sup in _supplierManager.GetAll())
            {
                Console.WriteLine("Code:\t\t" + sup.Code + "\nName:\t\t" + sup.Name + "\nAddress:\t" +
                    sup.Address + "\nEmail:\t\t" + sup.Email + "\nContact:\t" + sup.Contact + "" +
                    "\nContactPerson:\t" + sup.ContactPerson);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("For Single Supplier");
            Supplier supp = _supplierManager.GetById(1);
            Console.WriteLine("Code:\t\t" + supp.Code + "\nName:\t\t" + supp.Name + "\nAddress:\t" +
                    supp.Address + "\nEmail:\t\t" + supp.Email + "\nContact:\t" + supp.Contact + "" +
                    "\nContactPerson:\t" + supp.ContactPerson);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
