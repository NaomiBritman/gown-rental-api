using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Api;
using Dal.Models;

namespace Dal.Services
{
    public class CustomerService : ICustomer
    {
        DataManager datamanager;
        public CustomerService(DataManager datamanager)
        {
            this.datamanager = datamanager;
        }
        public void CreateCustomer(Customer c)
        {
            this.datamanager.Customers.Add(c);
        }

        public void DeleteCustomer(string id)
        {
           Customer customer = datamanager.Customers.ToList().Find(x => x.Id == id);
            if (customer != null)
            {
                this.datamanager.Customers.Remove(customer);
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return this.datamanager.Customers.ToList();
        }

        public Customer GetCustomerById(string id)
        {
            Customer customer = datamanager.Customers.ToList().Find(x => x.Id == id);
            if (customer == null)
            {
                throw new ArgumentNullException("This customer doesn't exist");
            }
            return customer;
        }

        public void UpdateCustomer(Customer c)
        {
            Customer old = datamanager.Customers.ToList().Find(x => x.Id == c.Id);
            if (old == null)
            {
                throw new ArgumentNullException("this customer does not exist. you can't update it ");
            }
                old.Id = c.Id;
                old.Name = c.Name;
                old.Phone = c.Phone;
                old.Email = c.Email;

            // לא עשיתי
            // old.Appointments=c.Appointments;
            // old.Rentals=c.Rentals;
        }
    }
}
