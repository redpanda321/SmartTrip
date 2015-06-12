
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class City
    {
        public int Id { set; get; }

        public string CityName { set; get; }

        public string ImageUrl { set; get; }

		public string Summary { set; get; }

        public int Visited { set; get; }


        public int Days { set; get; }

        //many to one
        public int CountryId { set; get; }
       
    }
}