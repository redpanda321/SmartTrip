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
            Note = new Note();
            Trip = new Trip();
          
        }
        public int Id { set; get; }
        public string ScheduleName { set; get; }
        
        // one to one      
        public virtual Note Note { set; get; }
       
        //many to one
        public int TripId { set; get;  }
        public virtual Trip Trip { set; get; }

        public int HotelId { set; get; }
        public virtual Hotel Hotel { set; get; }
        
        //many to many
        public virtual ICollection<City> Cities { set; get; }
        public virtual ICollection<Transit> Transits { set; get; }
        public virtual ICollection<Scenery> Sceneries { set; get; }
      


    }
}