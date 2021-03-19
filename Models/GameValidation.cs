using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Arcade.Models
{
    public class GameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var game = (Game) validationContext.ObjectInstance;
            if (game.ReleaseDate == null)
                return new ValidationResult("Release Date is required");
            var age = DateTime.Today.Year - game.ReleaseDate.Value.Year;
            return (age > 0)
                ? ValidationResult.Success
                : new ValidationResult("You can not add unreleased game");
        }
    }
}