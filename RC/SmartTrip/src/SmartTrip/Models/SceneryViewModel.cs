using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace SmartTrip.Models
    
{

    public class SceneryViewModel
    {
        
        public List<Image> Images { set; get; }
        public Scenery Scenery { set; get; }

        public IEnumerable<SelectListItem> Cities { set; get; }

        public IEnumerable<SelectListItem> Categories { set; get; }

        public IEnumerable<SelectListItem> Currencies { set; get; }
       
    }
}