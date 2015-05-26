
using Microsoft.AspNet.Mvc.Rendering;
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class CityViewModel
    {
        public City City { get; set; }  
        public IEnumerable<SelectListItem> Countries { get; set; }

    }
}