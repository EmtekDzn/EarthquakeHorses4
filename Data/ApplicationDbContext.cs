using System;
using System.Collections.Generic;
using System.Text;
using EarthquakeHorses4.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EarthquakeHorses4.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EarthquakeHorses4.Models.Cheval> Cheval { get; set; }

        public DbSet<EarthquakeHorses4.Models.Contrat> Contrat { get; set; }

        public DbSet<EarthquakeHorses4.Models.Cour> Cour { get; set; }
    }
}
