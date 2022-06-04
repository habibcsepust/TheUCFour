using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUCFour.BLL.BLL;
using TheUCFour.Model.Model;

namespace ProductModule
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductManager _productManager = new ProductManager();
            CategoryManager _categoryManager = new CategoryManager();

            //For Add
            //Product product = new Product()
            //{
            //    Code = "p006",
            //    Name = "Symphony68",
            //    ReorderLevel = 20,
            //    Description = "Nice product..",
            //    CategoryId = 6
            //};

            //bool addProduct = _productManager.Add(product);

            //if (addProduct)
            //{
            //    Console.WriteLine("Saved");
            //}
            //else
            //{
            //    Console.WriteLine("Not Saved");
            //}


            //For Update
            //Product product = new Product()
            //{
            //    Id = 11,
            //    Code = "p007",
            //    Name = "Motors",
            //    ReorderLevel = 15,
            //    Description = "Nice product..",
            //    CategoryId = 6
            //};
            //bool updateProduct = _productManager.Update(product);
            //if (updateProduct)
            //{
            //    Console.WriteLine("Updated");
            //}
            //else
            //{
            //    Console.WriteLine("Not Updated");
            //}


            //For Delete
            //bool deleteProduct = _productManager.Delete(10);
            //if (deleteProduct)
            //{
            //    Console.WriteLine("Deleted");
            //}
            //else
            //{
            //    Console.WriteLine("Not Deleted");
            //}


            //For Display

            var result = _productManager.GetAll().Join(_categoryManager.GetAll(),
                    p => p.CategoryId,
                    c => c.Id,
                    (prodct, category) => new
                    {
                        ProductName = prodct.Name,
                        CategoryName = category.Name
                    });

            foreach (var product in result)
            {
                Console.WriteLine("ProductName: "+product.ProductName+"\t\t\tCategoryName: "+product.CategoryName);
            }





            //Console.WriteLine("For Multiple Products");
            //foreach (var prdct in _productManager.GetAll())
            //{
            //    Console.WriteLine("Code:\t\t" + prdct.Code + "\nName:\t\t" + prdct.Name + "\nReorderLevel:\t" +
            //        prdct.ReorderLevel + "\nDescription:\t" + prdct.Description + "\nCategoryId:\t" + prdct.CategoryId);
            //    Console.WriteLine();
            //}

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("For Single Products");
            //Product prduct = _productManager.GetById(2);
            //Console.WriteLine("Code: " + prduct.Code + "\tName: " + prduct.Name + "\tReorderLevel: " +
            //        prduct.ReorderLevel + "\tDescription: " + prduct.Description + "\tCategoryId: " + prduct.CategoryId);

            Console.ReadKey();
        }
    }
}
