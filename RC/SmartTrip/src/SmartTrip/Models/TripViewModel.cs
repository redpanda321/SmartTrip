using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc.Rendering;

namespace SmartTrip.Models
{
    public class TripViewModel
    {

        public TripViewModel()
        {

            Trip = new Trip();

            Countries = new List<Country>();

            Cities = new List<City>();

            CheckedCities = new List<CheckedCity>();

            Sceneries = new List<Scenery>();

            CheckedSceneries = new List<CheckedScenery>();
        }

        public Trip Trip { set; get; }

        public List<Country> Countries { set; get; }

        public List<City> Cities { set; get; }
        
        public List<CheckedCity> CheckedCities { set; get; }

        public List<Scenery> Sceneries { set; get; }

        public List<CheckedScenery> CheckedSceneries { set; get; }


    }


    public class CheckedCity 
    {
        public int CityId { set; get; }

        public bool Checked { set; get; }
    }

    public class CheckedScenery
    {
        public int SceneryId { set; get; }
        public bool Checked { set; get; }
    }
    

}