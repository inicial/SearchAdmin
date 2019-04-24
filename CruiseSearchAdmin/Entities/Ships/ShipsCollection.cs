using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CruiseSearchAdmin.Entities.Ships
{
    public class ShipsCollection:CSACollection,IEnumerable<Ship>
    {
        public override bool GetItems(SqlConnection connection)
        {
            return GetItemsForCruiseLine(-1, connection);
        }
        
        public bool GetItemsForCruiseLine(int clid, SqlConnection connection)
        {
            string query =
                @"select s.id,s.name_en,cruise_line_id,s.code,s.visible, cl.name_en from Ships as s join CruiseLines as cl on cruise_line_id=cl.id";
            if (clid > 0)
                query += string.Format(@" where cl.id={0}", clid);
             var dt =
                WorkWithData.GetDataTable(query
                    ,
                    connection);
            Clear();
            AddRange(from DataRow dr in dt.Rows select new Ship(dr,connection));
            if (Count == 0) return false;
            return true;
        }

        

        IEnumerator<Ship> IEnumerable<Ship>.GetEnumerator()
        {
            return GetShipsEnumerator();
        }
        private IEnumerator<Ship> GetShipsEnumerator()
        {
            IEnumerator ie = base.GetEnumerator();
            while (ie.MoveNext())
            {
                yield return (Ship)ie.Current;
            }
        }
    }
}