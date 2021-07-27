using SampleMvc5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleMvc5.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _dbContext;
        // GET: Customers
        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // dispose/destroy _dbContext
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        public ActionResult Index()
        {
            //var customers = GetCustomers();
            var customers = _dbContext.Customers.ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id=1,Name = "John Rambo"},
                new Customer{Id=2,Name = "Robert Downey" },
                new Customer{Id=3,Name = "Tom Cruise" },
            };
        }
    }
}