
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class Country
    {
        public int Id { set; get; }
        public string CountryName { set; get; }

        public string ImageUrl { set; get; }

        // one to many
        public virtual ICollection<City> Cities { set; get; }

    }
}