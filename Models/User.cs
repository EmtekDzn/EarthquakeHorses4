using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Models
{
    public class User : IdentityUser
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Description { get; set; }
    }
}
