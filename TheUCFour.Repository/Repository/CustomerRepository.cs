using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUCFour.DatabaseContext.DatabaseContext;
using TheUCFour.Model.Model;

namespace TheUCFour.Repository.Repository
{
    public class CustomerRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(Customer customer)
        {
            Customer singleCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);
            if (singleCustomer != null)
            {
                singleCustomer.Code = customer.Code;
                singleCustomer.Name = customer.Name;
                singleCustomer.Address = customer.Address;
                singleCustomer.Email = customer.Email;
                singleCustomer.Contact = customer.Contact;
                singleCustomer.LoyalityPoint = customer.LoyalityPoint;
            }

            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Customer singleCustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            if (singleCustomer != null)
            {
                _dbContext.Customers.Remove(singleCustomer);
                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public List<Customer> GetAll()
        {
            var customers = _dbContext.Customers.ToList();
            return customers;
        }
        public Customer GetById(int id)
        {
            Customer customer = _dbContext.Customers.FirstOrDefault(c => c.Id == id);
            return customer;
        }

        public bool ExistCuctomerCode(Customer customer)
        {
            bool isExistCustomerCode = false;
            Customer cust = _dbContext.Customers.FirstOrDefault(c => c.Code == customer.Code);
            if (cust != null)
            {
                isExistCustomerCode = true;
            }
            return isExistCustomerCode;
        }

        public bool ExistCuctomerEmail(Customer customer)
        {
            bool isExistCustomerEmail = false;
            Customer cust = _dbContext.Customers.FirstOrDefault(c => c.Email == customer.Email);
            if (cust != null)
            {
                isExistCustomerEmail = true;
            }
            return isExistCustomerEmail;
        }

        public bool ExistCuctomerContact(Customer customer)
        {
            bool isExistCustomerContact = false;
            Customer cust = _dbContext.Customers.FirstOrDefault(c => c.Contact == customer.Contact);
            if (cust != null)
            {
                isExistCustomerContact = true;
            }
            return isExistCustomerContact;
        }
    }
}
