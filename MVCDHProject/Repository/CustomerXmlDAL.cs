using MVCDHProject.Models;
using System.Collections.Generic;
using System.Data;
using System;
using MVCDHProject.IRepository;

namespace MVCDHProject.Repository
{
    public class CustomerXmlDAL: ICustomerXmlDAL
    {
        DataSet ds;
        public CustomerXmlDAL()
        {
            ds = new DataSet();
            ds.ReadXml("Customer.xml");
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns["Custid"] };
        }
        public List<Customer> Customers_Select()
        {
            List<Customer> Customers = new List<Customer>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Customer obj = new Customer
                {
                    Custid = Convert.ToInt32(dr["Custid"]),
                    Name = Convert.ToString(dr["Name"]),
                    Balance = Convert.ToDecimal(dr["Balance"]),
                    City = Convert.ToString(dr["City"]),
                    Status = Convert.ToBoolean(dr["Status"])
                };
                Customers.Add(obj);
            }
            return Customers;
        }
        public Customer Customer_Select(int Custid)
        {
            DataRow dr = ds.Tables[0].Rows.Find(Custid);
            Customer obj = new Customer
            {
                Custid = Convert.ToInt32(dr["Custid"]),
                Name = Convert.ToString(dr["Name"]),
                Balance = Convert.ToDecimal(dr["Balance"]),
                City = Convert.ToString(dr["City"]),
                Status = Convert.ToBoolean(dr["Status"])
            };
            return obj;
        }
        public void Customer_Insert(Customer customer)
        {
            DataRow dr = ds.Tables[0].NewRow();
            dr["Custid"] = customer.Custid;
            dr["Name"] = customer.Name;
            dr["Balance"] = customer.Balance;
            dr["City"] = customer.City;
            dr["Status"] = customer.Status;
            ds.Tables[0].Rows.Add(dr);
            ds.WriteXml("Customer.xml");
        }
        public void Customer_Update(Customer customer)
        {
            DataRow dr = ds.Tables[0].Rows.Find(customer.Custid);
            int Index = ds.Tables[0].Rows.IndexOf(dr);
            ds.Tables[0].Rows[Index]["Name"] = customer.Name;
            ds.Tables[0].Rows[Index]["Balance"] = customer.Balance;
            ds.Tables[0].Rows[Index]["City"] = customer.City;
            ds.WriteXml("Customer.xml");
        }
        public void Customer_Delete(int Custid)
        {
            DataRow dr = ds.Tables[0].Rows.Find(Custid);
            int Index = ds.Tables[0].Rows.IndexOf(dr);
            ds.Tables[0].Rows[Index].Delete();
            ds.WriteXml("Customer.xml");
        }
    }
}
