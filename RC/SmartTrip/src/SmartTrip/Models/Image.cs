using System;

namespace SmartTrip.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
       //many to one

       public int SceneryId { get; set; }
        
       public System.Nullable<int> HotelId { get; set; }   
           
    }
}