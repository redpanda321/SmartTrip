using System;
using System.Collections.Generic;

namespace SmartTrip.Models
{
    public class TransitClass {

        public  List<string> TransitType { set; get; }

        public TransitClass() {

            TransitType = new List<string>();

            TransitType.Add("plane");
            TransitType.Add("train");
            TransitType.Add("bus");
            TransitType.Add("taxi");
            TransitType.Add("ship");
            TransitType.Add("driving");
            TransitType.Add("other"); 
        }
       
    }

    public class Transit
    {
       public int Id { set; get; }

       public string TransitName { set; get; }

       public string TransitType { set; get; }

       public string TransitNumber { set; get; }

       public string StartingCity { set; get; }

        public string DestinationCity { set; get; }

       public DateTime StartTime { set; get; }

       public DateTime EndTime { set; get; }

       public Decimal Price { set; get; }

       public String Currency { set; get; }

       public int Amount { set; get; }

       public string Memo { set; get; }
        
        //many to one

       public int ScheduleId { set; get; }
    }
}