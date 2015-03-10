using System;

namespace SmartTrip.Models
{
    public class Comment
    {
        public int Id { set; get; }

        public string Content { set; get; }

        public DateTime Time { set; get; }

		public string UserName { set; get; }
       

    }

	public class CityComment : Comment {

        public int CityId { set; get; }
		public virtual City City { set; get; }
	}

	public class SceneryComment : Comment
	{
        public int SceneryId { set; get; }
        public virtual Scenery Scenery { set; get; }

	}

	public class HotelComment : Comment
	{
        public int HotelId { set; get; }
        public virtual Hotel Hotel { set; get; }

	}
}