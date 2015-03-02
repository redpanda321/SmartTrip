
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace SmartTrip.Models
{
    public class CityEditModel
    {
        
        public string CityName { set; get; }

        public string ImageUrl { set; get; }

		public string Summary { set; get; }

        public string CountryName { set; get; }

        public string UserName { set; get; }  

    }
}