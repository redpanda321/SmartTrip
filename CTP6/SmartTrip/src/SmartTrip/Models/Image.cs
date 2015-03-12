using System;

namespace SmartTrip.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
       //many to one

        public virtual Scenery Scenery { get; set; }
        
        public virtual Hotel Hotel {get;set;}
    }
}