using System;

namespace SmartTrip.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }

        public int SceneryId { get; set; }
        public virtual Scenery Scenery { get; set; }

        public int HotelId { get; set; }
        public virtual Hotel Hotel {get;set;}
    }
}