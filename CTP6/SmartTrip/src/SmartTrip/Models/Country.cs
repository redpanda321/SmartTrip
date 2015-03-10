
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class Country
    {

        public Country() {

            Cities = new HashSet<City>();
            Trips = new HashSet<Trip>();
        }
        public int Id { set; get; }
        public string CountryName { set; get; }
        
        //many to many
        public virtual ICollection<Trip> Trips { set; get; }
        // one to many
		public virtual ICollection<City> Cities { set; get; }

    }
}