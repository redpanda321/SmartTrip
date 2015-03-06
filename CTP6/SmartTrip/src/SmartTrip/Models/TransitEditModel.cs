using System;

namespace SmartTrip.Models
{
   
    public class TransitEditModel
    {

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

       public string UserName { set; get; }

    }
}