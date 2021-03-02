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
            return View();
        }
    }
}