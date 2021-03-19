using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Arcade.Dtos;
using Arcade.Models;
using AutoMapper;

namespace Arcade.Controllers.Api
{
    public class GamesController : ApiController
    {
        private ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET api/games

        public IHttpActionResult GetGames()
        {
            var gameDtos = _context.Games.Include(c => c.Genre).ToList().Select(Mapper.Map<Game, GamesDto>);
            return Ok(gameDtos);
        }

        //GET api/games/1

        public IHttpActionResult GetGame(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);
            if (game == null)
                return NotFound();
            return Ok(Mapper.Map<Game, GamesDto>(game));

        }

        // POST api/games
        [HttpPost]
        public IHttpActionResult CreateGame(GamesDto game)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var gameDto = Mapper.Map<GamesDto, Game>(game);
            _context.Games.Add(gameDto);
            _context.SaveChanges();

            game.Id = gameDto.Id;
            return Created(new Uri(Request.RequestUri + "/" + game.Id), game);
        }
        //Put api/games/1

        [HttpPut]
        public void UpdateGames(int id, GamesDto games)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var gameInDb = _context.Games.SingleOrDefault(c => c.Id == id);
            if (gameInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(games, gameInDb);
            gameInDb.Name = games.Name;
            gameInDb.ReleaseDate = games.ReleaseDate;
            gameInDb.GenreId = games.GenreId;
            gameInDb.DateAdded = games.DateAdded;


            _context.SaveChanges();

        }

        //Delete /api/customers/1
        [HttpDelete]

        public void DeleteGame(int id)
        {
            var gameInDb = _context.Games.SingleOrDefault(c => c.Id == id);
            if (gameInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Games.Remove(gameInDb);
            _context.SaveChanges();
        }
    }

}
