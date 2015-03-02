using System;


namespace SmartTrip.Models
{
    public class Transit
    {
       public int Id { set; get; }

       public string TransitName { set; get; }

       public enum TransitType { plane=1, train, bus, taxi,ship,driving,other }

       public string TransitNumber { set; get; }

       public virtual City StartingCity { set; get; }

        public virtual City DestinationCity { set; get; }

       public DateTime StartTime { set; get; }

       public DateTime EndTime { set; get; }

       public Decimal Price { set; get; }

       public String Currency { set; get; }

       public int Amount { set; get; }

       public string Memo { set; get; }


       public string UserName { set; get; }

    }
}