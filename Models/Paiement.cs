using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Models
{
    public class Paiement
    {
        public int Id { get; set; }
        public float Du { get; set; }
        public String Motif { get; set; }
        public String Type { get; set; }
        public String Detail { get; set; }
        public int ContratId { get; set; }
        public Contrat Contrat { get; set; }
    }
}
