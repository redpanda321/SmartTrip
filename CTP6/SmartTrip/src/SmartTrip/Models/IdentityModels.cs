using System;
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
        private static bool _created = false;

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
            // This is a temporary workaround to create database until Entity Framework database migrations 
            // are supported in ASP.NET 5

           
            if (!_created)
            {
                Database.AsMigrationsEnabled().ApplyMigrations();
                _created = true;
            }
            
        }
        
        protected override void OnConfiguring(DbContextOptions options)
        {
            options.UseSqlServer();
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