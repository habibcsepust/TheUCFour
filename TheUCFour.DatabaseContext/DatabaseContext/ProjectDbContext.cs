using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TheUCFour.Model.Model;

namespace TheUCFour.DatabaseContext.DatabaseContext
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetails { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetials> SaleDetials { get; set; }
    }
}
