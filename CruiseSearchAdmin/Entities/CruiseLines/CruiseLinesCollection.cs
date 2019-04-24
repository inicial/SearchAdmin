
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CruiseSearchAdmin.Entities.CruiseLines
{
    public class CruiseLinesCollection: CSACollection, IEnumerable<CruiseLine>
    {
       

        public CruiseLine this[int index]
        {
            get { return (CruiseLine)InnerList[index]; }
        }
        public override bool GetItems(SqlConnection connection)
        {
            this.Clear();
            var dt = WorkWithData.GetDataTable(@"SELECT CruiseLines.id,mnemo,code,name_ru,name_en,CruiseLines.visible,redirect,isnull(class,0) as class,currency,isnull(CruiseLineClass.name,0) as classname FROM CruiseLines left join CruiseLineClass on class = CruiseLineClass.id order by name_en", connection);
            AddRange(from DataRow dr in dt.Rows select new CruiseLine(dr,connection));
            if (Count == 0)return false;
            return true;
        }

        IEnumerator<CruiseLine> IEnumerable<CruiseLine>.GetEnumerator()
        {
            return GetCLIEnumrtator();
        }

        private IEnumerator<CruiseLine> GetCLIEnumrtator()
        {
            var ie = List.GetEnumerator();
            while (ie.MoveNext())
            {
                yield return (CruiseLine) ie.Current;
            }
            
        }
    }
}