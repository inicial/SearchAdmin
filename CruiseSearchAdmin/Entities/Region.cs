using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CruiseSearchAdmin.Entities
{
    [Serializable]
   

    public class ItRegion
    {
        public long ID { get; set; }
        public int? Parent_id { get; set; }
        public string Name { get; set; }
        public int Itinerary { get; set; } public int? Order  {  get; set;}

        public ItRegion(long id, string n, int? parent_id, int? order)

        {
            ID = id;
            Name = n;
            Parent_id = parent_id;
            Order = order;
        }

        public  ItRegion(long id, string n)
        {
            ID = id;
            Name = n;    
        }
        public ItRegion(DataRow dr)
        {
            ID = (long)dr.Field<double>("keyregion");
            //Parent_id = dr.Field<int?>("parent");
            Itinerary = (Convert.ToInt32(dr["itenary"]));
            
            Name = string.Empty;}

    }
}
