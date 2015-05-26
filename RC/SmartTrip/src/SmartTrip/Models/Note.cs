using System;

namespace SmartTrip.Models
{
    public class Note
    {
        public int Id { set; get; }
        public string Content { set; get; }
        //one to one 
        public virtual Schedule Schedule { set; get; }
    }
}