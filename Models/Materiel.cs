using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Models
{
    public class Materiel
    {
        public int Id { get; set; }
        public String Reference { get; set; }
        public float Tarif { get; set; }
        public String Type { get; set; }
        public float Taille { get; set; }
        public String Unite { get; set; }
        public String Couleur { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
