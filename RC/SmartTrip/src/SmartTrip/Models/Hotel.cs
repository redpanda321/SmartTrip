﻿using System;
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class Hotel
    {
        public int Id { set; get; }

        public string HotelName { set; get; }

        public string HotelAddress { set; get; }

        public Decimal Price { set; get; }

        public String Currency { set; get; }

        //assessment

        public int Star { set; get; }

        public int Score { set; get; }

        public string Traffic { set; get; }

        public int Hot { set; get; }

        public string Summary { set; get; }

        //many to one
        public int CityId { set; get; }
       

        //one to one
        public int ScheduleId { set; get; }

       

    }
}