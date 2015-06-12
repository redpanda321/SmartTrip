using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrip.Models
{
    public class Schedule
    {

        public Schedule() {


            ScheduleDate = new DateTime();
        }

       [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        public string ScheduleName { set; get; }
        
        public DateTime ScheduleDate { set; get; }
        
        public string StrCities { set; get; }   //CityId1 > CityId2

        public string StrSceneries { set; get; }

        public string StrHotels { set; get; }

        public string StrTransits { set; get; }

        public string StrNote { set; get; }


        //many to one
        public int TripId { set; get; }

      
    }
}