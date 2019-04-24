using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CruiseSearchAdmin.Entities
{
    [Serializable]
    public class Itinerary
    {
        public int ID { get; set; }
        public string Text { get; set; }

        public Itinerary(int id,string text)
        {
            ID = id;
            Text = text;
        }
        override public int GetHashCode()
        {
            return ID + Text.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Itinerary)) return false;
            return ID == ((Itinerary)obj).ID;
        }
    }
}
