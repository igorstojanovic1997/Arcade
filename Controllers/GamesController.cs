﻿using System;
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

            var game = _context.Games.Include(c=>c.Genre).FirstOrDefault(t => t.Id == id);

            return View(game);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewmodel = new NewGameViewModel()
            {
                Genres = genres
            };
            return View("GameForm", viewmodel);
        }
        [HttpPost]
        public ActionResult Create(Game game)
        {
            if (game.Id == 0)
                _context.Games.Add(game);
            else
            {
                var gameInDb = _context.Games.Single(c => c.Id == game.Id);
                gameInDb.Name = game.Name;
                gameInDb.GenreId = game.GenreId;
                gameInDb.ReleaseDate = game.ReleaseDate;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Games");
        }
        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);
            if (game == null)
                return HttpNotFound();
            var viewModel = new NewGameViewModel
            {
                Game = game,
                Genres = _context.Genres.ToList()
            };
            return View("GameForm", viewModel);
        }
    }
}