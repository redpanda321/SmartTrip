using System;
using System.Collections;
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class Trip
    {

        public Trip () {

            Schedules = new List<Schedule>();
            
            }
        public int Id { get; set; }

        public string TripName { get; set; }

        public DateTime StartTime { get; set; }

		public int Days { get; set; }


		public string UserName { get; set; }

		public virtual City StartingCity { get; set; }

        public virtual Country DestinationCountry { get; set; }

        public virtual ICollection<City> DestinationCities { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }


		


    }
}