using MVCDHProject.IRepository;
using MVCDHProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCDHProject.Repository
{
    public class CustomerSqlDAL : ICustomerSqlDAL
    {
        private readonly MVCCoreDbContext context;
        public CustomerSqlDAL(MVCCoreDbContext context)
        {
            this.context = context;
        }
        public List<Customer> Customers_Select()
        {
            var customers = context.Customers.Where(C => C.Status == true).ToList();
            return customers;
        }
        public Customer Customer_Select(int Custid)
        {
            return context.Customers.Find(Custid);
        }
        public void Customer_Insert(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }
        public void Customer_Update(Customer customer)
        {
            customer.Status = true;
            context.Update(customer);
            context.SaveChanges();
        }
        public void Customer_Delete(int Custid)
        {
            Customer customer = context.Customers.Find(Custid);
            customer.Status = false;
            context.SaveChanges();
        }

    }
}
