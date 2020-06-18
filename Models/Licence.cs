using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Models
{
    public class Licence
    {
        public int Id { get; set; }
        public int Validite { get; set; }
        public float Tarif { get; set; }
        public String Niveau { get; set; }
        public String Categorie { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
