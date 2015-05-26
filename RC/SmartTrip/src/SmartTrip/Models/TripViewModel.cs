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
            SelectedCities = new List<City>();

            CheckedCities = new List<CheckedCity>();
        }

        public Trip Trip { set; get; }

        public List<Country> Countries { set; get; }


        public List<City> Cities { set; get; }

        public List<City> SelectedCities { set; get; }

        public List<CheckedCity> CheckedCities { set; get; }


    }


    public class CheckedCity 
    {
        public int CityId { set; get; }

        public bool Checked { set; get; }
    }
    

}