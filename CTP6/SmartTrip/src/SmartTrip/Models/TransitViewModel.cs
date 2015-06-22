using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace SmartTrip.Models
{
   
    public class TransitViewModel
    {

      public Transit Transit { get; set; }

        public IEnumerable<SelectListItem> Cities { set; get; }

        public IEnumerable<SelectListItem> TransitTypes { set; get; }

        public IEnumerable<SelectListItem> Currencies { set; get; }

    }
}