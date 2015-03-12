using System;
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class Schedule
    {
        Schedule() {

          
        }
        public int Id { set; get; }
        public string ScheduleName { set; get; }
        
       //many to one
    
        public virtual Trip Trip { set; get; }

        // one to one 
       
        public virtual Note Note { set; get; }


        public virtual Hotel Hotel { set; get; }

        //one to  many
        public virtual ICollection<City> Cities { set; get; }
        public virtual ICollection<Transit> Transits { set; get; }
        public virtual ICollection<Scenery> Sceneries { set; get; }
      


    }
}