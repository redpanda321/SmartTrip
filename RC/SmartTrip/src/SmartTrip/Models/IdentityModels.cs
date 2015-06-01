using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Framework.OptionsModel;

namespace SmartTrip.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private static bool _created;

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Hotel> Hotels { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Scenery> Sceneries { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Transit> Transits { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<CityComment> CityComments { get; set; }

        public DbSet<SceneryComment> SceneryComments { get; set; }

        public DbSet<HotelComment> HotelComments { get; set; }

        public DbSet<Image> Images { get; set; }




        public ApplicationDbContext()
        {
            // Create the database and schema if it doesn't exist

           /*
            if (!_created)
            {
                Database.AsRelational().ApplyMigrations();
                _created = true;
            }
           */
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
