
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

        //many to one
        public int CountryId { set; get; }
        public virtual Country Country { set; get; }

        
        public virtual Trip Trip { set; get; }
        public virtual Schedule Schedule {set;get;}

        //one to many
        public virtual ICollection<CityComment> CityComments { set; get; }

    }
}