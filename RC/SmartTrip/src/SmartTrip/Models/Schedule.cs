using System;
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class Schedule
    {
       public  Schedule() {


        }
        public int Id { set; get; }

        public string ScheduleName { set; get; }
        
        public DateTime ScheduleDate { set; get; }
        
        public string StrCities { set; get; }   //CityId1 > CityId2

        //

        public string StrSceneries { set; get; }

        public string StrHotels { set; get; }

        public string StrTransits { set; get; }

        public string StrNote { set; get; }


        //many to one
        public int TripId { set; get; }

        public virtual Trip Trip { set; get; }

        // one to one 
        public virtual Note Note { set; get; }

        //one to  many
        public virtual ICollection<Hotel> Hotels { set; get; }
        public virtual ICollection<City> Cities { set; get; }
        public virtual ICollection<Transit> Transits { set; get; }
        public virtual ICollection<Scenery> Sceneries { set; get; }

        


    }
}