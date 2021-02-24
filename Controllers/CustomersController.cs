using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Arcade.Models;
using Arcade.ViewModels;

namespace Arcade.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        public CustomersController(ApplicationDbContext ctx)
        {
            _ctx = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer{Name="John"},
                new Customer{Name="Mary"}

            };
            var viewModel = new IndexCustomersViewModel
            {
                Customers = customers
            };
            return View(viewModel);
        }
        //Customers/Details
        //public ActionResult Details(int id)
        //{

        //    var customer = _ctx.Customers.FirstOrDefault(t => t.Id == id);
             
        //    return View();
        //}
    }
}