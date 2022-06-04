using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUCFour.BLL.BLL;
using TheUCFour.Model.Model;

namespace CategoryModule
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryManager _categoryManager = new CategoryManager();


            //Add Category with multiple product
            //Category category = new Category()
            //{
            //    Code = "c101",
            //    Name = "Mobile",
            //    Products = new List<Product>()
            //    {
            //        new Product()
            //        {
            //            Code = "p103",
            //            Name = "Samsungj7",
            //            ReorderLevel = 12,
            //            Description = "Nice Capturing to show",
            //        },
            //        new Product()
            //        {
            //            Code = "p104",
            //            Name = "Nokia3200",
            //            ReorderLevel = 15,
            //            Description = "Very good",
            //        }
            //    }
            //};

            //Product product = new Product()
            //{
            //    Code = "p005",
            //    Name = "Huawei Ldn Lx2",
            //    ReorderLevel = 10,
            //    Description = "Nice product.."
            //};

            //category.Products.Add(product);
            //bool addCategory = _categoryManager.Add(category);

            //if (addCategory)
            //{
            //    Console.WriteLine("Saved");
            //}
            //else
            //{
            //    Console.WriteLine("Not Saved");
            //}
            
            //****************Update****************
            //Category aCategory = new Category();
            //aCategory.Id = 2;
            //aCategory.Code = "C102";
            //aCategory.Name = "Freezes";
            //Category aCat = new Category()
            //{
            //    Id = 6,
            //    Code = "C100",
            //    Name = "Electronics"
            //};

            //if (_categoryManager.Update(aCat))
            //{
            //    Console.WriteLine("Updated..");
            //}
            //else
            //{
            //    Console.WriteLine("Not Updated..");
            //}


            Console.WriteLine("For Multiple Category");
            Console.WriteLine();
            foreach (var cate in _categoryManager.GetAll())
            {
                Console.WriteLine("Category Code:\t" + cate.Code+ "\nCategory Name:\t" + cate.Name+ "\n\n\tProducts List:");
                if (cate.Products != null && cate.Products.Any())
                {
                    foreach (var prodct in cate.Products)
                    {
                        Console.WriteLine("\t\tCode:\t\t" + prodct.Code + "\n\t\tName:\t\t" + prodct.Name + "\n\t\tReorderLevel:\t" + prodct.ReorderLevel +
                            "\n\t\tDescription:\t" + prodct.Description);
                        Console.WriteLine();
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("For Single Category");
            Console.WriteLine();
            Category cat = _categoryManager.GetById(6);
            Console.WriteLine("Category Code:\t" + cat.Code + "\nCategory Name:\t" + cat.Name + "\n\n\tProducts List:");
            if (cat.Products != null && cat.Products.Any())
            {
                foreach (var prodct in cat.Products)
                {
                    Console.WriteLine("\t\tCode:\t\t" + prodct.Code + "\n\t\tName:\t\t" + prodct.Name + "\n\t\tReorderLevel:\t" + prodct.ReorderLevel +
                            "\n\t\tDescription:\t" + prodct.Description);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("\t\t\tNo Student Found");
            }

            //********Add*******
            //Category category = new Category()
            //{
            //    Code = "C103",
            //    Name = "Clothes"
            //};

            //if (_categoryManager.Add(category))
            //{
            //    Console.WriteLine("Category Saved..");
            //}
            //else
            //{
            //    Console.WriteLine("Category Not Saved..");
            //}

            //*******Delete*******
            //if (_categoryManager.Delete(4))
            //{
            //    Console.WriteLine("Category Deleted..");
            //}
            //else
            //{
            //    Console.WriteLine("Category Not Deleted..");
            //}

            //*******Update*******
            //Category aCategory = new Category();
            //aCategory.Id = 2;
            //aCategory.Code = "C102";
            //aCategory.Name = "Freezes";

            //if (_categoryManager.Update(aCategory))
            //{
            //    Console.WriteLine("Category Updated..");
            //}
            //else
            //{
            //    Console.WriteLine("Category Not Updated..");
            //}

            //*******GetAll*******
            //Console.WriteLine("All Category ");
            //List<Category> categories = _categoryManager.GetAll();
            //foreach (Category cat in categories)
            //{
            //    Console.WriteLine("Code:\t"+ cat.Code+"\tName:\t"+ cat.Name);
            //}

            ////*******Single Category*******
            //Console.WriteLine("Single Category ");
            //Category category = _categoryManager.GetById(1);
            //Console.WriteLine("Code:\t" + category.Code + "\tName:\t" + category.Name);

            Console.ReadKey();
        }
    }
}
