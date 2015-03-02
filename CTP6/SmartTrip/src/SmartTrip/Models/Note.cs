using System;

namespace SmartTrip.Models
{
    public class Note
    {
        public int Id { set; get; }
        public string Content { set; get; }

        public virtual Schedule Schedule { set; get; }

		public string UserName { set; get; }
    }
}