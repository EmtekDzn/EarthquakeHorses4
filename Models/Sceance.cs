using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Models
{
    public class Sceance
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int ContratId { get; set; }
        public Contrat Contrat { get; set; }
        public int CourId { get; set; }
        public Cour Cour { get; set; }
        public int LieuId { get; set; }
        public Lieu Lieu { get; set; }
//        public ICollection<User> Users { get; set; }
    }
}
