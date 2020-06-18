using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Models
{
    public class Pension
    {
        public int Id { get; set; }
        public float Tarif { get; set; }
        public int Engagement { get; set; }
        public String Type { get; set; }
        public String Detail { get; set; }
        public int ContratId { get; set; }
        public Contrat Contrat { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ChevalId { get; set; }
        public Cheval Cheval { get; set; }
    }
}
