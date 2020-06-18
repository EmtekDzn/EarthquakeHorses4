using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Models
{
    public class Information
    {
        public int Id { get; set; }
        public String Text { get; set; }
        public String Lieu { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
