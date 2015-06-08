using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartTrip.Models
{
    public class Trip
    {

        public Trip()
        {
            StartTime = DateTime.Now;
        }

        public int Id { get; set; }

        public string TripName { get; set; }
 
        [ScaffoldColumn(false)]
        public string UserName { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

		public int Days { get; set; } //schedule amount
       
		public string StartingCity { get; set; }

        //one to many
        public virtual ICollection<Schedule> Schedules { get; set; }

        public virtual ICollection<City> Cities { get; set; }

    

    }
}