using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartTrip.Models
{
    public class ScheduleViewModel
    {

        public ScheduleViewModel() {


            Schedule = new Schedule();
            Sceneries = new List<Scenery>();
            Transits = new List<Transit>();
            Hotels = new List<Hotel>();
            Cities = new List<City>();
            CheckedCities = new List<CheckedCity>();
            CheckedSceneries = new List<CheckedScenery>();

        }
        
        public Schedule Schedule { get; set; }

        public List<Scenery> Sceneries { get; set; }

        public List<Transit> Transits { get; set; }

        public List<Hotel> Hotels { get; set; }

        public List<City> Cities { get; set; }

        public List<CheckedCity> CheckedCities { get; set; }

        public List<CheckedScenery> CheckedSceneries { get; set; }
      
    }
}