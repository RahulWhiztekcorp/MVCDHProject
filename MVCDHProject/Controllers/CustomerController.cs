using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCDHProject.IRepository;
using MVCDHProject.Models;
using MVCDHProject.Repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace MVCDHProject.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        public readonly ICustomerXmlDAL obj;
        public CustomerController(ICustomerXmlDAL _obj)
        {
            obj = _obj;
        }
        [AllowAnonymous]
        public ViewResult DisplayCustomers()
        {
            //obj = (ICustomerSqlDAL)HttpContext.RequestServices.GetService(typeof(ICustomerSqlDAL));
            return View(obj.Customers_Select());
        }
        [AllowAnonymous]
        public ViewResult DisplayCustomer(int Custid)
        {
            return View(obj.Customer_Select(Custid));
        }
        [Authorize]
        public ViewResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public RedirectToActionResult AddCustomer(Customer customer)
        {
            obj.Customer_Insert(customer);
            return RedirectToAction("DisplayCustomers");
        }
        [Authorize]
        public ViewResult EditCustomer(int Custid)
        {
            return View(obj.Customer_Select(Custid));
        }
        public RedirectToActionResult UpdateCustomer(Customer customer)
        {
            obj.Customer_Update(customer);
            return RedirectToAction("DisplayCustomers");
        }
        [Authorize]
        public RedirectToActionResult DeleteCustomer(int Custid)
        {
            obj.Customer_Delete(Custid);
            return RedirectToAction("DisplayCustomers");
        }
    }
}
