﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartTrip.Models
{
    public class Trip
    {
        public Trip() {

            StartTime = new DateTime();

        }
       

        public int Id { get; set; }

        public string TripName { get; set; }
 
        [ScaffoldColumn(false)]
        public string UserName { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        public string StartCity { get; set; } //Beijing 

        public string TripDays { get; set; } //i > j > k
       
        public string TripCities { get; set; } //  Calgary > Banff

        public string ImageUrl { get; set; }
       
    }
}