using System;
using Arcade.Models;

namespace Arcade.Dtos
{
    public class GamesDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }


    }
}