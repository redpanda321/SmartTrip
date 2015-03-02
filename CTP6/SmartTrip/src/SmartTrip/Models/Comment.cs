using System;

namespace SmartTrip.Models
{
    public class Comment
    {
        public int Id { set; get; }

        public string Content { set; get; }

        public DateTime Time;

		public string UserName { set; get; }
       

    }

	public class CityComment : Comment {


		public virtual City City { set; get; }
	}

	public class SceneryComment : Comment
	{
		public virtual Scenery Scenery { set; get; }

	}

	public class HotelComment : Comment
	{
		public virtual Hotel Hotel { set; get; }

	}
}