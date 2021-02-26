using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arcade.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}