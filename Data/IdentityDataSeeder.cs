using EarthquakeHorses4.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarthquakeHorses4.Data
{
    public class IdentityDataSeeder
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            SeedRoles(roleManager);

            if(await userManager.FindByNameAsync("arthur@sicard.fr") == null)
            {
                User gerant = new User
                {
                    UserName = "arthur@sicard.fr",
                    Email = "arthur@sicard.fr",
                    Nom = "Sicard",
                    Prenom = "Arthur",
                    Description = "Gerant"
                };

                IdentityResult result = await userManager.CreateAsync(gerant, "Azertyuiop-1");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(gerant, "Gerant");
                }
            }

            if (await userManager.FindByEmailAsync("pa@lagadec.fr") == null)
            {
                User secretaire = new User
                {
                    UserName = "pa@lagadec.fr",
                    Email = "pa@lagadec.fr",
                    Nom = "Lagadec",
                    Prenom = "Pierre-Alban",
                    Description = "Secretaire"
                };

                IdentityResult result = await userManager.CreateAsync(secretaire, "Azertyuiop-1");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(secretaire, "Secretaire");
                }
            }
        }
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Gerant").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Gerant"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Secretaire").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Secretaire"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Palefrenier").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Palefrenier"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Cavalier").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Cavalier"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Adherent").Result)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Adherent"
                };
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
