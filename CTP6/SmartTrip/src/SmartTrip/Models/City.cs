
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class City
    {
        public City() {

           
            CityComments = new HashSet<CityComment>();

        }

        public int Id { set; get; }

        public string CityName { set; get; }

        public string ImageUrl { set; get; }

		public string Summary { set; get; }

        public int Visited { set; get; }

        //many to one
        public int CountryId { set; get; }
        public virtual Country Country { set; get; }


        //one to many
        public virtual ICollection<CityComment> CityComments { set; get; }

        //many to many
        public virtual ICollection<Trip> Trips { set; get; }
        public virtual ICollection<Schedule> Schedules { set; get; }

    }
}