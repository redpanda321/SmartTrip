using System;
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class Schedule
    {
        Schedule() {

            Cities = new List<City>();
            Transits = new List<Transit>();
            Sceneries = new List<Scenery>();

        }
        public int Id { set; get; }
        public string ScheduleName { set; get; }

        public virtual ICollection<City> Cities { set; get; }

        public virtual  ICollection<Transit> Transits { set; get; }

        public virtual  ICollection<Scenery> Sceneries { set; get; }

        public virtual Note Note { set; get; }

		public string UserName { set; get; }


    }
}