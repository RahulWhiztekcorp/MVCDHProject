using MVCDHProject.Models;
using System.Collections.Generic;

namespace MVCDHProject.IRepository
{
    public interface ICustomerSqlDAL
    {
        public List<Customer> Customers_Select();
        public Customer Customer_Select(int Custid);
        public void Customer_Insert(Customer customer);
        public void Customer_Update(Customer customer);
        public void Customer_Delete(int Custid);
    }
}
