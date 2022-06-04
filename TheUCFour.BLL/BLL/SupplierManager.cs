using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUCFour.Model.Model;
using TheUCFour.Repository.Repository;

namespace TheUCFour.BLL.BLL
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();

        public bool Add(Supplier supplier)
        {
            return _supplierRepository.Add(supplier);
        }

        public bool Delete(int id)
        {
            return _supplierRepository.Delete(id);
        }

        public bool Update(Supplier supplier)
        {
            return _supplierRepository.Update(supplier);
        }

        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll();
        }

        public Supplier GetById(int id)
        {
            return _supplierRepository.GetById(id);
        }

        public bool ExistSupplierCode(Supplier supplier)
        {
            return _supplierRepository.ExistSupplierCode(supplier);
        }

        public bool ExistSupplierEmail(Supplier supplier)
        {
            return _supplierRepository.ExistSupplierEmail(supplier);
        }

        public bool ExistSupplierContact(Supplier supplier)
        {
            return _supplierRepository.ExistSupplierContact(supplier);
        }
    }
}
