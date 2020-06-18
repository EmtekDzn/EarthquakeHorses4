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

        public DbSet<EarthquakeHorses4.Models.Information> Information { get; set; }

        public DbSet<EarthquakeHorses4.Models.Licence> Licence { get; set; }

        public DbSet<EarthquakeHorses4.Models.Lieu> Lieu { get; set; }

        public DbSet<EarthquakeHorses4.Models.LocationMateriel> LocationMateriel { get; set; }

        public DbSet<EarthquakeHorses4.Models.Materiel> Materiel { get; set; }

        public DbSet<EarthquakeHorses4.Models.Paiement> Paiement { get; set; }

        public DbSet<EarthquakeHorses4.Models.Pension> Pension { get; set; }

        public DbSet<EarthquakeHorses4.Models.Sceance> Sceance { get; set; }

        public DbSet<EarthquakeHorses4.Models.SceanceUser> SceanceUser { get; set; }
    }
}
