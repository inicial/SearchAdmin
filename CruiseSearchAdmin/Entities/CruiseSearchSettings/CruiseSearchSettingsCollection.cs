using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CruiseSearchAdmin.Entities;

namespace CruiseSearchAdmin.Forms.CruiseSearchSettings
{
    public class CruiseSearchSettingsCollection:CSACollection,IEnumerable<CruiseSearchSetting>
    {
        public override bool GetItems(SqlConnection connection)
        {
            var dt = WorkWithData.GetDataTable(@"select * from mk_CruiseSearchSettings",connection);
            Clear();
            AddRange(from DataRow dr in dt.Rows select new CruiseSearchSetting(dr,connection));
            if (Count < 1) return false;
            return true;
        }

         IEnumerator<CruiseSearchSetting> IEnumerable<CruiseSearchSetting>.GetEnumerator()
         {
             return GetSCSEnumerator();
         }

        private IEnumerator<CruiseSearchSetting> GetSCSEnumerator()
        {
            var ie = List.GetEnumerator();
            while (ie.MoveNext())
            {
                yield return (CruiseSearchSetting) ie.Current;
            }
        }
    }
}