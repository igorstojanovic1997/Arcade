using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Arcade.Models;

namespace Arcade.Dtos
{
    public class CustomerDto
    {
        
            public int Id { get; set; }
            [Required]
            [StringLength(255)]
            public string Name { get; set; }
            public string MembershipTypeName { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
            public byte MembershipTypeId { get; set; }
            // [Min18Years]
            public DateTime? Birthdate { get; set; }
        
    }
}