using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Models
{
    public class SceanceUser
    {
        public int Id { get; set; }
        public int SceanceId { get; set; }
        public Sceance Sceance { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
