using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Models
{
    public class LocationMateriel
    {
        public int Id { get; set; }
        public int ContratId { get; set; }
        public Contrat Contrat { get; set; }
        public int MaterielId { get; set; }
        public Materiel Materiel { get; set; }
        public String Lieu { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
