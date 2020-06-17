using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Models
{
    public class Cheval
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        //public DateTime Naissance { get; set; }
        public float Taille { get; set; }
        public String Robe { get; set; }
        public String Photo { get; set; }
        public int UserId { get; set; }
    }
}
