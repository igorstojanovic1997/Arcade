using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Arcade.Models;
using Arcade.ViewModels;

namespace Arcade.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games/
        public ActionResult Index()
        {
            var game = new List<Game>
            
            {
                new Game{Name = "GTA 5"},
                new Game { Name = "RDR2" }


            };
            var viewModel = new RandomGameViewModel
            {
                Game = game
            };
            return View(viewModel);
        }
        [Route("games/released/{year}/{month:regex(\\d{4})}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month );
        }
    }
}