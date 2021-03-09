using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Arcade.Models;
using Arcade.ViewModels;
using System.Data.Entity;

namespace Arcade.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _ctx;

        public CustomersController()
        {
            _ctx = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _ctx.Customers.Include(c=>c.MembershipType).ToList();
            var viewmodel = new IndexCustomersViewModel
            {
                Customers = customers
            };
            return View(viewmodel);
        }
        //Customers/Details
        public ActionResult Details(int id)
        {

            var customer = _ctx.Customers.Include(mt=>mt.MembershipType).FirstOrDefault(t => t.Id == id);
             
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _ctx.MembershipTypes.ToList();
            var viewmodel = new NewCustomerViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _ctx.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewmodel);
            }
            if (customer.Id==0)
                _ctx.Customers.Add(customer);
            else
            {
                //Mapper.Map(customer, customerInDb)
                var customerInDb = _ctx.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;



            }
            _ctx.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _ctx.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _ctx.MembershipTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }
    }
}