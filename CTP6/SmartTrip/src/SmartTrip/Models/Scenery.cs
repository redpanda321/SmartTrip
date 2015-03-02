using System;
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class Scenery
    {
        public int Id { set; get; }

        public string SceneryName { set; get; }

        public ICollection<string> ImageUrls { set; get; }

        //assessment
        public int Star { set; get; }

        public int Score { set; get; }

        public int Visited { set; get; }

        public int Ranking { set; get; }

        public string Summary { set; get; }

        //basic info
        public string Ticket { set; get; }

        public string OpenTime { set; get; }

        public string Traffic { set; get; }

        public string WebUrl { set; get; }

        public enum Category { scenery=1,cate, service,shopping}

        public string Tel { set; get; }

        //
        public Decimal Price { set; get; }
        public String Currency { set; get; }

        public virtual ICollection<SceneryComment> SceneryComments { set; get; }

        public virtual City City { set; get; }

		public string UserName { set; get; }
    }
}