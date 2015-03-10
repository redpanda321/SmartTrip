using System;
using System.Collections;
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class Trip
    {
        
        public int Id { get; set; }

        public string TripName { get; set; }

        public string UserName { get; set; }

        public DateTime StartTime { get; set; }

		public int Days { get; set; }
       
		public string StartingCity { get; set; }

        //one to many
        public virtual ICollection<Schedule> Schedules { get; set; }

        // many to many
        public virtual ICollection<Country>  DestinationCountries { get; set; }
        public virtual ICollection<City> DestinationCities { get; set; }

       

		


    }
}