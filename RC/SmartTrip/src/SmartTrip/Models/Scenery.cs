using System;
using System.Collections.Generic;

namespace SmartTrip.Models
{

    public  class   Category {

     public List<string> CategoryType { set; get; }

     public Category() {

            CategoryType = new List<string>();
            CategoryType.Add("scenery");
            CategoryType.Add("activity");
            CategoryType.Add("cate");
            CategoryType.Add("shopping");
            CategoryType.Add("traffic");
        }

    }
   
    public class Scenery
    {
       
        public int Id { set; get; }

        public string SceneryName { set; get; }
        
        //assessment
        public int Star { set; get; }

        // 
        public int Score { set; get; }

        public int Visited { set; get; }

        public int Ranking { set; get; }
        //

        public string Summary { set; get; }

        //basic info
        public string Ticket { set; get; }

        public string OpenTime { set; get; }

        public string Traffic { set; get; }

        public string WebUrl { set; get; }

        public string Category { set; get; }

        public string Telephone { set; get; }

        public Decimal Price { set; get; }
        public string Currency { set; get; }
        
        //many to one
        public int CityId { set; get; }
        public int ScheduleId  { set; get; }

        //one to many
        public virtual ICollection<Image> Images { set; get; }
        public virtual ICollection<SceneryComment> SceneryComments { set; get; }

        
	
    }
}