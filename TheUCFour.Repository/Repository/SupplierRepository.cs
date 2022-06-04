using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TheUCFour.DatabaseContext.DatabaseContext;
using TheUCFour.Model.Model;

namespace TheUCFour.Repository.Repository
{
    public class SupplierRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool Add(Supplier supplier)
        {
            _dbContext.Suppliers.Add(supplier);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Supplier supplier = _dbContext.Suppliers.FirstOrDefault(c => c.Id == id);
            if (supplier != null)
            {
                _dbContext.Suppliers.Remove(supplier);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public bool Update(Supplier supplier)
        {
            Supplier supplr = _dbContext.Suppliers.FirstOrDefault(c => c.Id == supplier.Id);
            if (supplr!=null)
            {
                supplr.Code = supplier.Code;
                supplr.Name = supplier.Name;
                supplr.Address = supplier.Address;
                supplr.Email = supplier.Email;
                supplr.Contact = supplier.Contact;
                supplr.ContactPerson = supplier.ContactPerson;
            }
            return _dbContext.SaveChanges() > 0;
        }

        public List<Supplier> GetAll()
        {
            var suppliers = _dbContext.Suppliers.ToList();
            return suppliers;
        }

        public Supplier GetById(int id)
        {
            Supplier supplier = _dbContext.Suppliers.FirstOrDefault(c => c.Id == id);
            return supplier;
        }

        public bool ExistSupplierCode(Supplier supplier)
        {
            bool isExistSupplierCode = false;
            Supplier sup = _dbContext.Suppliers.FirstOrDefault(c => c.Code == supplier.Code);
            if (sup != null)
            {
                isExistSupplierCode = true;
            }
            return isExistSupplierCode;
        }

        public bool ExistSupplierEmail(Supplier supplier)
        {
            bool isExistSupplierEmail = false;
            Supplier sup = _dbContext.Suppliers.FirstOrDefault(c => c.Email == supplier.Email);
            if (sup != null)
            {
                isExistSupplierEmail = true;
            }
            return isExistSupplierEmail;
        }

        public bool ExistSupplierContact(Supplier supplier)
        {
            bool isExistSupplierContact = false;
            Supplier sup = _dbContext.Suppliers.FirstOrDefault(c => c.Contact == supplier.Contact);
            if (sup != null)
            {
                isExistSupplierContact = true;
            }
            return isExistSupplierContact;
        }
    }
}
