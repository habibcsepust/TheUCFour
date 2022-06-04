using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUCFour.Model.Model;
using TheUCFour.Repository.Repository;

namespace TheUCFour.BLL.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public bool Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public bool Delete(int id)
        {
            return _customerRepository.Delete(id);
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public bool ExistCuctomerCode(Customer customer)
        {
            return _customerRepository.ExistCuctomerCode(customer);
        }

        public bool ExistCuctomerEmail(Customer customer)
        {
            return _customerRepository.ExistCuctomerEmail(customer);
        }

        public bool ExistCuctomerContact(Customer customer)
        {
            return _customerRepository.ExistCuctomerContact(customer);
        }
    }
}
