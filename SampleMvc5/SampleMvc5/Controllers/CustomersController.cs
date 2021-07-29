using SampleMvc5.Models;
using SampleMvc5.ViewModels;
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
            var customers = _dbContext.Customers.Include("MembershipType").ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _dbContext.Customers.Include("MembershipType").SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _dbContext.MembershipTypes.ToArray();
            var customerFormViewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", customerFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var customerViewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _dbContext.MembershipTypes.ToArray()
                };
                return View("CustomerForm", customerViewModel);
            }
            if (customer.Id == 0)
            {
                // insert
                var birth = DateTime.Parse(customer.BirthDate.ToString("dd/MM/yyyyy"));
                customer.BirthDate = birth;
                _dbContext.Customers.Add(customer);
            }
            else
            {
                // update
                var existingCustomer = _dbContext.Customers.Include("MembershipType").FirstOrDefault(x => x.Id == customer.Id);
                if (existingCustomer != null)
                {
                    existingCustomer.Name = customer.Name;
                    existingCustomer.BirthDate = customer.BirthDate;
                    existingCustomer.MembershipTypeId = customer.MembershipTypeId;
                    existingCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                }
            }
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var customerViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _dbContext.MembershipTypes.ToArray()
            };

            return View("CustomerForm", customerViewModel);
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