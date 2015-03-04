﻿using System;
using System.Collections.Generic;

namespace SmartTrip.Models
    
{

    public class SceneryEditModel
    {

        
        public string SceneryName { set; get; }

        public ICollection<string> ImageUrls { set; get; }

        //assessment
        public int Star { set; get; }

        public string Summary { set; get; }

        //basic info
        public string Ticket { set; get; }

        public string OpenTime { set; get; }

        public string Traffic { set; get; }

        public string WebUrl { set; get; }


        public string Category { set; get; }

        public string Telephone { set; get; }

        //
        public Decimal Price { set; get; }
        public string Currency { set; get; }

        public string CityName { set; get; }

        
		public string UserName { set; get; }
    }
}