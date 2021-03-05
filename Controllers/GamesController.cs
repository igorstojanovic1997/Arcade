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
    public class GamesController : Controller

    {
        private readonly ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Games/
        public ViewResult Index()
        {
            var games = _context.Games.ToList();
            var viewmodel = new RandomGameViewModel
            
            {
                Games = games

            };
            
            return View(viewmodel);
        }
        [Route("games/released/{year}/{month:regex(\\d{4})}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month );
        }
        //Games/Details
        public ActionResult Details(int id)
        {

            var game = _context.Games.FirstOrDefault(t => t.Id == id);

            return View(game);
        }

        public ActionResult New()
        {
            return View();
        }
    }
}