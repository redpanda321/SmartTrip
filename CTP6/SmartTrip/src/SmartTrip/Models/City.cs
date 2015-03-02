
using System.Collections.Generic;


namespace SmartTrip.Models
{
    public class City
    {
        public int Id { set; get; }

        public string CityName { set; get; }

        public string ImageUrl { set; get; }

		public string Summary { set; get; }

        public string CountryName { set; get; }

        public string UserName { set; get; }

      

		public virtual Country Country { set; get; }

		public int Visited { set; get; }

		public virtual ICollection<CityComment> CityComments { set; get; }
       
    }
}