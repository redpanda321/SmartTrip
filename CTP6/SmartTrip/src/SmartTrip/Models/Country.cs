
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class Country
    {
        public int Id { set; get; }
        public string CountryName { set; get; }

		public string UserName { set; get; }

		public virtual ICollection<City> Cities { set; get; }

    }
}