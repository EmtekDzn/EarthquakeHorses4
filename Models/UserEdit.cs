using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Models
{
    public class UserEdit
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Description { get; set; }
    }
}
